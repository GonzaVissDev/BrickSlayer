using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{

    private Rigidbody2D Rb2D;
    public float Speed = 150f;

    // Start is called before the first frame update
    void Start()
    {
        Rb2D = GetComponent<Rigidbody2D>();
    }
    private void FixedUpdate()
    {
        // Get Horizontal Input
        float PlayerMovement = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
         Rb2D.velocity = Vector2.right * PlayerMovement * Speed;
    }
}
