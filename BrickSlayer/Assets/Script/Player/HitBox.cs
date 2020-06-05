using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitBox : MonoBehaviour
{
    private GameManager Gm;

    void Start()
    {
        GameObject GmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (GmObject != null) { Gm = GmObject.GetComponent<GameManager>(); }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Projectile")
        {
            Gm.LoseLife();
        }
    }
}
