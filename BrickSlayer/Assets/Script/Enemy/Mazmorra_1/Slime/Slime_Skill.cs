using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Slime_Skill :BlockScript
{
//    private BlockScript So_enemy;
    private EnemyGrid Grid;
    private BlockScript bs;

    public GameObject ObjectToSummon;
    public GameObject ParticleSummon;
  
    private List<Vector3> PosicionesOpcupadas = new List<Vector3>();
    private Vector3[] PosicionesaInvocar;
    private Vector3 NewSlime;

     void Start(){
        //So_enemy = GetComponent<BlockScript>();

        //Debug.Log(So_enemy.Stats.Prabability);
        GameObject GridObject = GameObject.FindGameObjectWithTag("Grid");
        if(GridObject != null){ Grid = GridObject.GetComponent<EnemyGrid>(); 

        }
    }

    public override void ActivateSkill(){
     
        if (Probability == Rare.Commun)
        {
            FindObjectOfType<AudioManager>().Play("Slime_Hit");
            //No hace nada
        }
        if (Probability == Rare.raro)
        {
            FindObjectOfType<AudioManager>().Play("Slime_Hit");
            SummonRngSlime();
        }
        if (Probability == Rare.epico)
        {
            FindObjectOfType<AudioManager>().Play("Slime_Hit");
            SummonRngSlime();
         
        }
    }


    public void SummonRngSlime()
    {
        

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

            Grid.SaveBrick.Add(NewSlime);

            FindObjectOfType<AudioManager>().Play("Slime_Up");
            Instantiate(ParticleSummon, NewSlime, transform.rotation);
            Instantiate(ObjectToSummon, NewSlime, transform.rotation);


        }

        PosicionesOpcupadas.Clear();
    }



}



