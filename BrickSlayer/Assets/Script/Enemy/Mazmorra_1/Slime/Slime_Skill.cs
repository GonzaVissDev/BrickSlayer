using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  class Slime_Skill :BlockScript
{
//    private BlockScript So_enemy;
    private EnemyGrid Grid;
    private BlockScript bs;

    public GameObject ObjectToSummon;


     void Start(){
        //So_enemy = GetComponent<BlockScript>();

        //Debug.Log(So_enemy.Stats.Prabability);
        GameObject GridObject = GameObject.FindGameObjectWithTag("Grid");
        if(GridObject != null){ Grid = GridObject.GetComponent<EnemyGrid>(); }

   

    }
    


   public override void ActivateSkill(){
        if (Probability == Rare.Commun)
        {
          //No hace nada
        }
        if (Probability == Rare.raro)
        {
            int RandomNumber = Random.Range(0, Grid.Enemy_Position.Length);

            if (RandomNumber != Grid.SaveBrick.Count)
            {
                Instantiate(ObjectToSummon, Grid.Enemy_Position[RandomNumber], transform.rotation);
                
            }

        }
        if (Probability == Rare.epico)
        {
            int RandomNumber = Random.Range(0, Grid.Enemy_Position.Length);

            if (RandomNumber != Grid.SaveBrick.Count)
            {
                Instantiate(ObjectToSummon, Grid.Enemy_Position[RandomNumber], transform.rotation);
                RandomNumber = Random.Range(0, Grid.Enemy_Position.Length);
                Instantiate(ObjectToSummon, Grid.Enemy_Position[RandomNumber], transform.rotation);

            }

        }
    }

}



