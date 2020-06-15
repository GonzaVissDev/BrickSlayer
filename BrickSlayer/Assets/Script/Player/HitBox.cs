using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private GameManager Gm;
    public bool Rdy = false;
    private BoxCollider2D box;


    void Start()
    {
        //CONFIIGURAR QUE LA HITBOX APAREZCA DESPUES DE "X" PARA EVITAR VIDA INFINITA
        box = GetComponent<BoxCollider2D>();
        
        GameObject GmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (GmObject != null) { Gm = GmObject.GetComponent<GameManager>(); }
    }

    private void Update()
    {
        if (Rdy == true)
        {
            box.enabled = true;
        }

    }
  

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Sword")
        {
            Gm.LoseLife();
        }
        if (collision.gameObject.tag == "Projectile")
        {
            Gm.LoseLife();
        }
    }
}
