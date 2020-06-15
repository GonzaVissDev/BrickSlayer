using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagoProyectil :MonoBehaviour
{
    public float multipler = 1.1f;
    public float minSpeed = 1;
    public float maxSpeed = 5;
    public float curSpeed = 0;
    public float Cd = 10f;

    public enum ProyectilState { Confundir,Paralizar,Dmg};
    public ProyectilState Pstate = ProyectilState.Confundir;
    private Rigidbody2D rgb2;


    //[ FALTA CREAR UN METODO QUE DESTRUYA E INVOQUE UNA PARTICULA]
    private void Start()
    {
        rgb2 = GetComponent<Rigidbody2D>();
        rgb2.AddRelativeForce(new Vector3(0,-minSpeed, 0));
        Destroy(this.gameObject, Cd);
    }


    private void FixedUpdate()
    {
        curSpeed = Vector3.Magnitude(rgb2.velocity);

        if (curSpeed > maxSpeed) rgb2.velocity /= curSpeed / maxSpeed;

        if (curSpeed < minSpeed && curSpeed > 0) rgb2.velocity /= curSpeed / minSpeed;
    }


    private void  OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (Pstate == ProyectilState.Confundir)
            {
                collision.gameObject.GetComponent<PlayerScript>().Playerstate = PlayerScript.BuffState.Confudido;
                Destroy(this.gameObject);
            }
            if (Pstate == ProyectilState.Paralizar)
            {
                collision.gameObject.GetComponent<PlayerScript>().Playerstate = PlayerScript.BuffState.Dmg;
                Destroy(this.gameObject);
            }
            if (Pstate == ProyectilState.Dmg)
            {
                Destroy(this.gameObject);
            }

        }

    }
}
