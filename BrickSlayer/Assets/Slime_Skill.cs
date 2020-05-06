using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime_Skill : MonoBehaviour
{
    private BlockScript So_enemy;
    private EnemyGrid Grid;

    public GameObject ObjectToSummon;


     void Start(){
        So_enemy = GetComponent<BlockScript>();
        GameObject GridObject = GameObject.FindGameObjectWithTag("Grid");
        if(GridObject != null){ Grid = GridObject.GetComponent<EnemyGrid>(); }

    }


    public void ActivateSkill ()
    {
        if (So_enemy.Stats.Prabability == ScriptableEnemy.LootRate.Commun)
        {
            //No hace nada
            Debug.Log("Soy un Slime Comun");
        }


        if (So_enemy.Stats.Prabability == ScriptableEnemy.LootRate.Rare)
        {
            int RandomNumber = Random.Range(0, Grid.Enemy_Position.Length);

            if (RandomNumber != Grid.SaveBrick.Count)
            {
                Instantiate(ObjectToSummon, Grid.Enemy_Position[RandomNumber], transform.rotation);
                Debug.Log("Soy un Slime Raro ");
            }
        }

        if (So_enemy.Stats.Prabability == ScriptableEnemy.LootRate.Epic)
        {
            //Invoca dos slime Raros
            Debug.Log("Soy un Slime Epico");
        }
    }
}
