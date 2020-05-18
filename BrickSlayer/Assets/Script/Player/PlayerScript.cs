using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D Rb2D;
    public float Speed = 150f;
    private GameManager Gm;

     Vector3 StartPosition = new Vector3(0, -3, 0);

    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartPosition;
        Rb2D = GetComponent<Rigidbody2D>();

        GameObject GmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (GmObject != null) { Gm = GmObject.GetComponent<GameManager>(); }


    }
    private void FixedUpdate()
    {
        // Get Horizontal Input
        float PlayerMovement = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
         Rb2D.velocity = Vector2.right * PlayerMovement * Speed;
    }



}
