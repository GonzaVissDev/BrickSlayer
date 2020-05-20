using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BlockScript : MonoBehaviour
{
    private EnemyGrid GridScript;
    public ScriptableEnemy Stats;
    private Slime_Skill slime;
   



    //Propiedades del Enemigo
    private  int Life;
    private float  Speed;
    private int  ScoreValue;
    private string Anim_Name;
    private Animator Anim;
    public  enum Rare{ Commun, raro, epico ,legendario };
    public  Rare Probability;

    private void Awake()
    {
        GameObject ScriptObject = GameObject.FindGameObjectWithTag("Grid");
        if (ScriptObject != null) GridScript = ScriptObject.GetComponent<EnemyGrid>();

        slime = GetComponent<Slime_Skill>();
        Life = Stats.Life;
        Speed = Stats.Speed;
        ScoreValue = Stats.ScoreValue;
        Anim_Name = Stats.AniamtionName;

        switch (Stats.Prabability)
        {
            case ScriptableEnemy.LootRate.Commun:

                Probability = Rare.Commun;

                break;

            case ScriptableEnemy.LootRate.Rare:

                Probability = Rare.raro;
                break;

            case ScriptableEnemy.LootRate.Epic:

                Probability = Rare.epico;

                break;

            case ScriptableEnemy.LootRate.Legendary:

                Probability = Rare.legendario;
                break;
        }
    }


    public virtual void ActivateSkill()
    { }

    public virtual void Hp_Manager(int Dmg)
    {
        Life -= Dmg;
        ActivateSkill();

        if (Life <= 0)
        {
            Debug.Log("Me llego el dmg" + Dmg);
            //Agregar Animacion de Hit...
            Destroy(this.gameObject,0.3f);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Hp_Manager(1);
      
   
     
    }


}
