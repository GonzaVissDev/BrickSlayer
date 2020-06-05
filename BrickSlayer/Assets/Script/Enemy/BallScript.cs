using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    //Caracteristicas de la Espada.
    public int Damage;
    private int Count;
    public float speed = 10f;
    //Componentes:

    private Rigidbody2D rb2d;
    private Animator anim;
    private bool SwordInPlay = false;
    public bool Go = false;
 

    // Use this for initialization
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        //  rb2d.velocity = Vector2.up * speed;
    }

    private void Update()
    {
        anim.SetBool("Spin", Go);
        if (Go == true && SwordInPlay == false)
        {
            transform.parent = null;
            SwordInPlay = true;
            rb2d.isKinematic = false;
            rb2d.velocity = Vector2.up * speed;

        }

    }


    float hitFactor(Vector2 ballPos, Vector2 racketPos,
                float racketWidth)
    {
        // ascii art:
        //
        // 1  -0.5  0  0.5   1  <- x value
        // ===================  <- racket
        //
        return (ballPos.x - racketPos.x) / racketWidth;
    }



    //Falta crear un contador que aumente cada vez que choca contra la pared, y si choca mas de 4 veces o mas tire la pelota para una direccion y se reincie el contador.
    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.tag == "Player")
        {
            Count = 0;
            Debug.Log("Toque al splayer");
            // Calculate hit Factor
            float x = hitFactor(transform.position,
                              col.transform.position,
                              col.collider.bounds.size.x);

            // Calculate direction, set length to 1
            Vector2 dir = new Vector2(x, 1).normalized;

            // Set Velocity with dir * speed
            GetComponent<Rigidbody2D>().velocity = dir * speed;
        }

        //Cree una variable que compara si choca contra la pared mas de 6 veces se mueve hacia arriba, asi evitamos el bug de rebote horizontal.
        //No olvides de poner los contadores en 0 cada vez que choca con el enemigo y player.
        if (col.gameObject.tag == "Wall")
        {
            Count++;
            if (Count > 6)
            {
                rb2d.velocity = Vector2.up * speed;
                Debug.Log("Tengo que salir ");
            }
            Count = 0;

        }

        if (col.gameObject.tag == "Enemy")
        {
            Count = 0;
            Debug.Log("Toque al enemigo");
            col.gameObject.GetComponent<BlockScript>().Hp_Manager(Damage);

        }


    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Hit")
        {
            Destroy(collision.gameObject);

        }
    }

}


