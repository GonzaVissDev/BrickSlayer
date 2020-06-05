using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeKing : BlockScript
{
    public float RangeStain;
    public float Time;
    public GameObject Stain;
    public GameObject[] Slime;
    private CameraEffect cam;
    public PlayerScript player;
    private EnemyGrid Grid;
    private List<Vector3> PosicionesOpcupadas = new List<Vector3>();
    private Vector3[] PosicionesaInvocar;
    private Animator anim;
    public int LifeJump;
    private Vector3 NewSlime;
    // Start is called before the first frame update
    void Start()
    {
        GameObject GridObject = GameObject.FindGameObjectWithTag("Grid");
        if (GridObject != null) { Grid = GridObject.GetComponent<EnemyGrid>(); }

        GameObject CameraObject = GameObject.FindGameObjectWithTag("MainCamera");
        if (CameraObject != null) { cam = CameraObject.GetComponent<CameraEffect>(); }





        anim = GetComponent<Animator>();


        //Variable para indicar que cada mitad de vida salte el slime y vibre todo.

        LifeJump = Life / 2;

        InvokeRepeating("SummonRngSlime", 3f, Time);

        if (Input.GetKeyDown(KeyCode.U))
        {
            anim.SetBool("Jump", true);
        }
    }

    private void Update()
    {
        if (Life < LifeJump)
        {
            LifeJump = Life / 2;
            anim.SetBool("Jump", true);
        }

    }

    public override void ActivateSkill()
    {
        Vector3 spawnPosition = this.transform.position + Random.onUnitSphere * RangeStain;
        Instantiate(Stain, spawnPosition, transform.rotation);
    }


    public void Jump()
    {
        GameObject PlayerObject = GameObject.FindGameObjectWithTag("Player");
        if (PlayerObject != null) { player = PlayerObject.GetComponent<PlayerScript>(); }

        player.Playerstate = PlayerScript.BuffState.Confudido;
        anim.SetBool("Jump", false);
        cam.ShakeIt();
    }


    //Totalmente Renovado y actualizado, de como tiene que invocar y asi evitar slime uno arriba del otro.
    public void SummonRngSlime()
    {
        int RandomSlime = Random.Range(0, Slime.Length);

        foreach (var x in Grid.Enemy_Position)
        {
            if (Grid.SaveBrick.Contains(x) == false)
            {
                PosicionesOpcupadas.Add(x);

            }
        }
        PosicionesaInvocar = PosicionesOpcupadas.ToArray();
        int randomNumber = Random.Range(0, PosicionesOpcupadas.Count);

        if (randomNumber < PosicionesaInvocar.Length)
        {
            NewSlime = PosicionesaInvocar[randomNumber];

            Debug.Log("New position" + NewSlime);
            Grid.SaveBrick.Add(NewSlime);

            Instantiate(Slime[RandomSlime], NewSlime, transform.rotation);


        }

        PosicionesOpcupadas.Clear();
    }
}
