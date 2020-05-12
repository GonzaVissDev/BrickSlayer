using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyGrid : MonoBehaviour
{
    //Enemigos Totales del mapa.
    public GameObject[] Enemy;
    
    //Posicion Enemiga
    public GameObject EnemyInGrid;
    
    //Lista de Posiciones de Enemigos
    [HideInInspector]
    public Vector3[] Enemy_Position;

    List<Vector3> globlalPosition = new List<Vector3>();

    private Vector3 spawnPosition;
    public Vector3 Grid_original = Vector3.zero;


    //Lista para guardar los Brick ya Instalados.
    [HideInInspector]
    public List<Vector3> SaveBrick = new List<Vector3>();


    //Componentes de la Cuadrilla.
    public int Grid_X;
    public int Grid_Y;
    public float Grid_Space = 1f;

    private bool Summon;

    private GameManager Gm;

    
    private void Start()
    {
        Gm = GetComponent<GameManager>();
        GameObject GmObject = GameObject.FindGameObjectWithTag("GameManager");
        if (GmObject!= null){ Gm = GmObject.GetComponent<GameManager>();}
        SpawnGrid();
    }
   
    void SpawnGrid()
    {
       for (int x=0; x< Grid_X;x++)
        {
            for(int y=0;y< Grid_Y;y++)
            {
                spawnPosition = new Vector3(x * Grid_Space, y * Grid_Space, 0) + Grid_original;
                globlalPosition.Add(spawnPosition);
                Instantiate(EnemyInGrid, spawnPosition, Quaternion.identity);
           
               
            }
        }

        Enemy_Position = globlalPosition.ToArray();

       //For para invocar a todos los enemigos.
            for (int i= 0; i<Enemy.Length;i++)
            {
                 if(Enemy[i] != null)
            {
            
            Instantiate(Enemy[i],Enemy_Position[i], transform.rotation);
            SaveBrick.Add(Enemy_Position[i]);


            }
          }
          
    }


    private void Update()
    {
        Object[] EnemyInScne = GameObject.FindGameObjectsWithTag("Enemy");
        if (EnemyInScne.Length == 0)
        {
            //Si hay 0 enemigos en scena gano!.
            Gm.WinGame();
            
        }
  
    }
}
 







