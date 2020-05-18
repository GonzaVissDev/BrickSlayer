using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float SwordInitialVelocity = 600f;
    private Rigidbody2D rb2d;
   public  bool SwordInPlay;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
    
    }




    private void Update()
    {
        if (Input.GetButtonDown("Fire1") && SwordInPlay == false)
        {
            transform.parent = null;
            SwordInPlay = true;
            rb2d.isKinematic = false;
            rb2d.AddForce(new Vector2(SwordInitialVelocity, SwordInitialVelocity));
        }
    }


}
