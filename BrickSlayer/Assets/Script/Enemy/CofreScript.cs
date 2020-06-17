using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CofreScript : MonoBehaviour
{
    public GameObject[] Coins;
    public GameObject Particula;
    private Animator anim;


    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void DropTheCoin ()
    {
        int RandomNumber = Random.Range(0, Coins.Length);
        Instantiate(Particula, transform.position, transform.rotation);
        Instantiate(Coins[RandomNumber], transform.position, transform.rotation);
       
        Destroy(this.gameObject, 0.3f);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Sword")
        {
            FindObjectOfType<AudioManager>().Play("Cofre");
            anim.Play("Open");
        }
    }


}
