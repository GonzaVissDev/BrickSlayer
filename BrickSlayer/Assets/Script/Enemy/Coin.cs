using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private Rigidbody2D rgb2d;

    public enum BuffState {Paralizado, Confudido, VelocidadUp, VelocidadDown, Escudo };
    public BuffState Playerstate = BuffState.VelocidadUp;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 5f);
        rgb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rgb2d.velocity = Vector2.down * 5f;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("Power_UP");
            switch (Playerstate)
            {

                //[Buff Velocidad]
                case (BuffState.VelocidadUp):
                    collision.gameObject.GetComponent<PlayerScript>().Playerstate = PlayerScript.BuffState.VelocidadUp;
                    break;

                //[Debuff Velocidad]
                case (BuffState.VelocidadDown):
                    collision.gameObject.GetComponent<PlayerScript>().Playerstate = PlayerScript.BuffState.VelocidadDown;
                    break;

                //[Escudo Mas Grande]
                case (BuffState.Escudo):
                    collision.gameObject.GetComponent<PlayerScript>().Playerstate = PlayerScript.BuffState.Escudo;
                    break;

                //[Debuff Pralaizado]
                case (BuffState.Paralizado):
                    collision.gameObject.GetComponent<PlayerScript>().Playerstate = PlayerScript.BuffState.Dmg;
                    break;

                //[Debuff Confudido]
                case (BuffState.Confudido):
                    collision.gameObject.GetComponent<PlayerScript>().Playerstate = PlayerScript.BuffState.Confudido;
                    break;

            }
            Destroy(this.gameObject);
        }
    }
}
