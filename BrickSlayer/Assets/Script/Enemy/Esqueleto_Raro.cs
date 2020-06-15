using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esqueleto_Raro : BlockScript
{
    
    public float  Min_CD =5;
    public float Max_CD = 10;
    public float CD = 10f;
    public GameObject Flecha;
    

    // Start is called before the first frame update
    void Start()
    {
        float RandomCd = Random.Range(Min_CD, Max_CD);
        CD = RandomCd;
        InvokeRepeating("Attack", CD, CD);
    }





    void Attack ()
    {
     
        Instantiate(Flecha, transform.position, transform.rotation);
    }
}
