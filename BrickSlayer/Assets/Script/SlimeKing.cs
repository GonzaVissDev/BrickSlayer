using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeKing : BlockScript
{
    public float RangeStain;
    public float Time;
    public GameObject Stain;
    public GameObject[] Slime;

    private EnemyGrid Grid;
    private List<Vector3> PosicionesOpcupadas = new List<Vector3>();
    private Vector3[] PosicionesaInvocar;

    // Start is called before the first frame update
    void Start()
    {
        GameObject GridObject = GameObject.FindGameObjectWithTag("Grid");
        if (GridObject != null) { Grid = GridObject.GetComponent<EnemyGrid>(); }

        InvokeRepeating("InvokeSlime", 3f, Time);
    }

    public override void ActivateSkill()
    {
        Vector3 spawnPosition = this.transform.position + Random.onUnitSphere * RangeStain;
        Instantiate(Stain, spawnPosition, transform.rotation);
    }

    void InvokeSlime()
    {
        SummonRngSlime();

    }

    public void SummonRngSlime()
    {
        int RandomSlime = Random.Range(0, Slime.Length);

        for (int i = 0; i < Grid.Enemy_Position.Length; i++)
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
        Instantiate(Slime[RandomSlime], PosicionesaInvocar[randomNumber], transform.rotation);


    }
}
