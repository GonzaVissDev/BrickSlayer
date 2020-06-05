using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float multipler = 1.1f;
    public float minSpeed = 1;
    public float maxSpeed = 5;
    public float curSpeed = 0;
    public bool Go = false;
    private bool SwordInPlay = false;

    private Rigidbody2D rb2d;
    private Animator anim;
    

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //rb2d.AddRelativeForce(new Vector3(0, minSpeed, 0));
    }


    private void Update()
    {
        anim.SetBool("Spin", Go);
        if (Go == true && SwordInPlay == false)
        {
            transform.parent = null;
            SwordInPlay = true;
            rb2d.isKinematic = false;
            rb2d.AddRelativeForce(new Vector3(0, minSpeed, 0));
        }
    }


    private void FixedUpdate()
    {
        curSpeed = Vector3.Magnitude(rb2d.velocity);

        if (curSpeed > maxSpeed) rb2d.velocity /= curSpeed / maxSpeed;

        if (curSpeed < minSpeed && curSpeed > 0) rb2d.velocity /= curSpeed / minSpeed;
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Falta comprar si colisiona contra un enemigo y enviarle la informacion del dmg.
        //Tambien falta comprar si le pega a la Hitbox del Aliado.

        /* Este Script sirve para que aumente su velocidad cada vez que golpea algo.
        */
         rb2d.velocity += rb2d.velocity * multipler;



    }
   


}
