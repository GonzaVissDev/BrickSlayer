using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private Animator anim;
    private bool SwordInPlay = false;
    public bool Go = false;
    public int Damage;
    // Movement Speed
    public float speed = 10f;

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




    void OnCollisionEnter2D(Collision2D col)
    {
        // Hit the Racket?
        if (col.gameObject.tag == "Player")
        {
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

        if (col.gameObject.tag == "Enemy")
        {
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

