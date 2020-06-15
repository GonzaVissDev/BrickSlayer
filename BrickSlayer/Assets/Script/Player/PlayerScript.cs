using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //[Componentes Del Jugador]
    private Rigidbody2D Rb2D;
    public float Speed = 10f;
    private float StartSpeed;
    public GameObject PlayerSword;
    public Transform SwordPosiiton;
   
    
    private Animator anim;
    Vector3 StartPosition = new Vector3(0, -3, 0);
  
    private GameManager Gm;
    private HitBox box;
    private bool EspadaEquipada;

    private Shield Shieldsp;
    Vector2 movimiento;
 
    //[BUFF / DEBUFF] - PARAMETROS // MACHINE STATE

    public enum BuffState {Normal,Dmg,Confudido,VelocidadUp,VelocidadDown,Escudo};
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
        EspadaEquipada = false;
        Rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        box = GetComponentInChildren<HitBox>();
        Shieldsp = GetComponentInChildren<Shield>();

        GameObject GmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (GmObject != null) { Gm = GmObject.GetComponent<GameManager>(); }
    }


    private void Update()
    {

       

        //Agregue la comparacion de disparo y ahora tambien compara si el gm esta listo para empezar.
        if (Input.GetButtonDown("Fire1") && Gm.RdyToPlay == true && EspadaEquipada == false)
        {
            EspadaEquipada = true;
            Invoke("SwordinGame", 0.35f);
            anim.SetTrigger("Attack");
            box.Rdy = true;
          //  sw.Go = true;
           
        }



        //Configuracion animacion 

        movimiento = new Vector2(Input.GetAxisRaw("Horizontal"), 0);

        if (movimiento != Vector2.zero && DEBUFF_STUN == false)
        {
            anim.SetFloat("MovX", movimiento.x);
            anim.SetBool("Walk", true);
        }
        else
        {
            anim.SetBool("Walk", false);
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
            case (BuffState.Dmg):
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

        if (DEBUFF_STUN == false)
        {
          
            Rb2D.velocity = Vector2.right * movimiento.x * Speed;
        }
    }


    public void SwordinGame ()
    {
        Instantiate(PlayerSword,SwordPosiiton.transform.position, transform.rotation);
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

        Object[] PlayerInScne = GameObject.FindGameObjectsWithTag("Sword");

        foreach (GameObject x in PlayerInScne)
        {
            x.gameObject.GetComponent<Sword>().PowerUp();
        
            
        }
        yield return new WaitForSeconds(3f);
       

    }

    public void ShieldUP()
    {
        Playerstate = BuffState.Normal;
        if (BUFF_SHIELD != true)
        {
            Shieldsp.ShieldUp();
            BUFF_SHIELD = true;
        }
    }
    
}
