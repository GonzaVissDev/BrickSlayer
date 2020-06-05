using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //[Componentes Del Jugador]
    private Rigidbody2D Rb2D;
    public float Speed = 10f;
    private float StartSpeed;
    private Animator anim;
    Vector3 StartPosition = new Vector3(0, -3, 0);
    private Sword sw;
    private GameManager Gm;

    //[BUFF / DEBUFF] - PARAMETROS // MACHINE STATE

    public enum BuffState {Normal,Paralizado,Confudido,VelocidadUp,VelocidadDown,Escudo};
    public BuffState Playerstate = BuffState.Normal;

    public bool DEBUFF_STUN = false;
    public bool BUFF_SHIELD = false;

    
    //[ITEMS]
    public GameObject Big_Shield;

    // Start is called before the first frame update
    void Start()
    {
        //Seteamos Las Velocidad y posicion inicial del jugador
        transform.position = StartPosition;
        StartSpeed = Speed;

        Rb2D = GetComponent<Rigidbody2D>();
        sw = GetComponentInChildren<Sword>();

        GameObject GmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (GmObject != null) { Gm = GmObject.GetComponent<GameManager>(); }
    }


    private void Update()
    {
        //Agregue la comparacion de disparo y ahora tambien compara si el gm esta listo para empezar.
        if (Input.GetButtonDown("Fire1") && Gm.RdyToPlay == true)
        {
            sw.Go = true;
        }

        switch (Playerstate){

            //[Buff Velocidad]
            case (BuffState.VelocidadUp):
                StartCoroutine(Velocidad(2));
                break;

           //[Debuff Velocidad]
            case (BuffState.VelocidadDown):
                StartCoroutine(SpeedDown());
                break;

           //[Escudo Mas Grande]
             case (BuffState.Escudo):
                ShieldUP();
                break;

         //[Debuff Pralaizado]
            case (BuffState.Paralizado):
                StartCoroutine(GetStunned());
                break;

           //[Debuff Confudido]
            case (BuffState.Confudido):
                StartCoroutine(Velocidad(-1));
                break;

        }
    }

    private void FixedUpdate()
    {
        // Get Horizontal Input
        float PlayerMovement = Input.GetAxisRaw("Horizontal");

        // Set Velocity (movement direction * speed)
        if (DEBUFF_STUN == false)
        {
            Rb2D.velocity = Vector2.right * PlayerMovement * Speed;
        }
    }

    //Crear todos los POWER-UP & DEBUFF

    IEnumerator Velocidad(int Sp)
    {
     
        Playerstate = BuffState.Normal;
        Speed = Speed * Sp;

        yield return new WaitForSeconds(10f);
        Speed = StartSpeed;
    }


    IEnumerator SpeedDown()
    {
   
        Playerstate = BuffState.Normal;
        float actualspeed = Speed;
        Speed = Speed / 2;

        yield return new WaitForSeconds(10f);
        Speed = actualspeed;
   
    }
    //FALTA ARREGLAR EL PARALIZADO
    IEnumerator GetStunned()
    {
        Playerstate = BuffState.Normal;
        DEBUFF_STUN = true;
        yield return new WaitForSeconds(3f);
        DEBUFF_STUN = false;

    }

    public void ShieldUP()
    {
        Playerstate = BuffState.Normal;
        if (BUFF_SHIELD != true)
        {
            // Vector3 ShieldPosition = new Vector3(transform.position.x, transform.position.y + 1, 0);
            //GameObject ShieldClone = Instantiate(Big_Shield, ShieldPosition, Quaternion.identity);
            // ShieldClone.transform.parent = transform;
            //FALTA CONFIGUAR QUE  SE ACTIVE LA ANIMACION DEL ESCUDO.
  
            BUFF_SHIELD = true;
        }
    }
    
}
