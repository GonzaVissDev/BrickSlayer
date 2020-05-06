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


    private void Start()
    {
        GameObject ScriptObject = GameObject.FindGameObjectWithTag("Grid");
        if (ScriptObject != null) GridScript = ScriptObject.GetComponent<EnemyGrid>();

        slime = GetComponent<Slime_Skill>();
        Life = Stats.Life;
        Speed = Stats.Speed;
        ScoreValue = Stats.ScoreValue;
        Anim_Name = Stats.AniamtionName;

}



    public void Hp_Manager(int Dmg)
    {
        Life -= Dmg;
        if (Life <= 0)
        {
            Debug.Log("Me llego el dmg" + Dmg);
            slime.ActivateSkill();
            //Agregar Animacion de Hit...
            Destroy(this.gameObject);
           

        }
    }


}
