using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public int Dmg = 1;
    public float multipler = 1.1f;
    public float minSpeed = 1;
    public float maxSpeed = 5;
    public float curSpeed = 0;
    public bool Go = false;
    private bool SwordInPlay = false;
    public GameObject Spark;

    private Rigidbody2D rb2d;
    private Animator anim;

    int contador = 0;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
      
    }


    private void Update()
    {
       
       
         if (SwordInPlay == false)
          {
            // transform.parent = null;
            anim.SetBool("Spin", Go);
            SwordInPlay = true;
              rb2d.isKinematic = false;
              rb2d.AddRelativeForce(new Vector3(0, minSpeed, 0));
          }
    }

    public void PowerUp()
    {
        Dmg = 5;
        anim.Play("PowerUP");
    }

    private void FixedUpdate()
    {
        curSpeed = Vector3.Magnitude(rb2d.velocity);

        if (curSpeed > maxSpeed) rb2d.velocity /= curSpeed / maxSpeed;

        if (curSpeed < minSpeed && curSpeed > 0) rb2d.velocity /= curSpeed / minSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            Instantiate(Spark, transform.position, transform.rotation);
            FindObjectOfType<AudioManager>().Play("Sword_Hit");
            contador++;
            if (contador> 7)
            {
                rb2d.AddForce(transform.up * 80f);
                contador = 0;
            }
        }
        if (collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<Slime_Skill>().Hp_Manager(Dmg);
        }
        if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<SlimeKing>().Hp_Manager(Dmg);
        }

        if (collision.gameObject.tag == "ESqueleto")
        {
            collision.gameObject.GetComponent<Esqueleto_Raro>().Hp_Manager(Dmg);
        }

        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Sword_Hit");
            Instantiate(Spark, transform.position, transform.rotation);

        }
        rb2d.velocity += rb2d.velocity * multipler;



    }
   


}
