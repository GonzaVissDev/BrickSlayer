using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto_Raro : BlockScript
{
    public float CD;
    public GameObject Flecha;
    

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Attack", 1f, CD);
    }





    void Attack ()
    {
        Instantiate(Flecha, transform.position, transform.rotation);
    }
}
