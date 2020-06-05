using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto_Epico : BlockScript
{

    public GameObject[] Projectiles;
    public int CD = 3;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InvokeSkill", 1f, CD);
    }

    void InvokeSkill ()
    {
        int randomNumber = Random.Range(0, Projectiles.Length);
        Instantiate(Projectiles[randomNumber], transform.position, transform.rotation);

    }
}
