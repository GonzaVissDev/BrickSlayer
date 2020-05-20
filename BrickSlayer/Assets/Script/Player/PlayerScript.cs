using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //[Componentes Del Jugador]
    private Rigidbody2D Rb2D;
    public float Speed = 10f;
    Vector3 StartPosition = new Vector3(0, -3, 0);
    private BallScript sw;
    private GameManager Gm;

    //[BUFF / DEBUFF] - PARAMETROS
    public bool DEBUFF_SPEED = false;
    public bool DEBUFF_STUN = false;
    public bool BUFF_SPEED = false;
    public bool BUFF_SHIELD = false;
    
    //[ITEMS]
    public GameObject Big_Shield;
  
    // Start is called before the first frame update
    void Start()
    {
        transform.position = StartPosition;
        Rb2D = GetComponent<Rigidbody2D>();
        sw = GetComponentInChildren<BallScript>();

        GameObject GmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (GmObject != null) { Gm = GmObject.GetComponent<GameManager>(); }


    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            sw.Go = true;
        }

        //TODO ESTO ES TEMPORAL; HAY Que rehacer un codigo mas limpio y ordenado. (SOLO ES PARA TESTEO)
        if ((Input.GetKeyDown(KeyCode.F1)))
        {
            StartCoroutine(SpeedUP());
            BUFF_SPEED = false;
        }
        if ((Input.GetKeyDown(KeyCode.F2)))
        {
            ShieldUP();
            BUFF_SHIELD = false;
        }
       if((Input.GetKeyDown(KeyCode.F3)))
        {
            StartCoroutine(SpeedDown());
             DEBUFF_SPEED = false;
        }
        if (Input.GetKeyDown(KeyCode.F4))
        {
            DEBUFF_STUN = true;
            StartCoroutine(GetStunned());
           
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

    IEnumerator SpeedUP()
    {
        float actualspeed = Speed;
        Speed = Speed * 2;

        yield return new WaitForSeconds(10f);
        Speed = actualspeed;
    }

    IEnumerator SpeedDown()
    {
        float actualspeed = Speed;
        Speed = Speed / 2;

        yield return new WaitForSeconds(10f);
        Speed = actualspeed;
    }

    IEnumerator GetStunned()
    {
        
        yield return new WaitForSeconds(3f);
        DEBUFF_STUN = false;

    }




    public void ShieldUP(){

        Vector3 ShieldPosition = new Vector3(transform.position.x, transform.position.y + 1, 0);
    GameObject ShieldClone =   Instantiate(Big_Shield, ShieldPosition, Quaternion.identity);
        ShieldClone.transform.parent = transform;
    }



}
