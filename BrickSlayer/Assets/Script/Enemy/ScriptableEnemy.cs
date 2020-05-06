using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Brick", menuName = "Brick")]
public class ScriptableEnemy :ScriptableObject
{
    public enum LootRate { Commun, Rare, Epic, Legendary };
    public LootRate Prabability = LootRate.Commun;

    public int Life;
    public float Speed;
    public int  ScoreValue;
    public string AniamtionName;
   
       
}
