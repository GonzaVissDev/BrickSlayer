using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equeleto_Skill : BlockScript
{
    private Rigidbody2D rgb2d;
    public float maxSpeed = 1f;
    public float Speed = 1f;

    private void Start()
    {
        rgb2d = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        rgb2d.AddForce(Vector2.right * Speed);
        float LimitSpeed = Mathf.Clamp(rgb2d.velocity.x, -maxSpeed, maxSpeed);
        rgb2d.velocity = new Vector2(LimitSpeed, rgb2d.velocity.y);

        if (rgb2d.velocity.x > -0.01f && rgb2d.velocity.x < 0.01f)
        {
            Speed = -Speed;
            rgb2d.velocity = new Vector2(Speed, rgb2d.velocity.y);
        }
    }

}
