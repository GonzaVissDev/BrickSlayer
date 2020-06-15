using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetRandomPosition
{
    //    private BlockScript So_enemy;
    private EnemyGrid Grid;
    private BlockScript bs;
    private List<Vector3> PosicionesOpcupadas = new List<Vector3>();
    private Vector3[] PosicionesaInvocar;

    void Start()
    {
        //So_enemy = GetComponent<BlockScript>();

        //Debug.Log(So_enemy.Stats.Prabability);
        GameObject GridObject = GameObject.FindGameObjectWithTag("Grid");
        if (GridObject != null) { Grid = GridObject.GetComponent<EnemyGrid>(); }


    }

    public Vector3 GetRNG_Position(Vector3 Position)
    {

        for (int i = 0; i<Grid.Enemy_Position.Length; i++)
            {
                foreach (var x in Grid.SaveBrick)
                {
                    if (Grid.Enemy_Position[i] != x)
                    {
                        PosicionesOpcupadas.Add(Grid.Enemy_Position[i]);

                    }
                }
            }

            PosicionesaInvocar = PosicionesOpcupadas.ToArray();
            int randomNumber = Random.Range(0, PosicionesOpcupadas.Count);
            Position = PosicionesaInvocar[randomNumber];

        return Position;
    }
}
