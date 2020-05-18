using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadyText : MonoBehaviour
{

    public enum ReadyState { Start, Ended };
    public ReadyState rdyState = ReadyState.Ended;
    public bool Readyend = false;

    private Sword py;


    [SerializeField]
    public Text RdyText;

    string ReadyText_1 = "3";
    string ReadyText_2 = "2";
    string ReadyText_3 = "1";
    string ReadyText_4 = "Go!";


    void Start()
    {

        RdyText.enabled = false;
        py = GetComponent<Sword>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject!= null){ py = playerObject.GetComponent<Sword>(); }
    }

    IEnumerator readytextController()
    {

        RdyText.text = ReadyText_1;
        yield return new WaitForSeconds(1);
        ReadyText_1 = ReadyText_2;
        yield return new WaitForSeconds(1);
        ReadyText_2 = ReadyText_3;
        yield return new WaitForSeconds(1);

        ReadyText_3 = ReadyText_4;
        yield return new WaitForSeconds(0.25f);
        rdyState = ReadyState.Ended;
        RdyText.enabled = false;
        Readyend = true;
      


    }

    void Update()
    {
        if (rdyState == ReadyState.Start && Readyend != true)
        {


            RdyText.enabled = true;
            StartCoroutine(readytextController());
        }
        if (rdyState == ReadyState.Ended && Readyend == true)
        {

            RdyText.enabled = false;



        }
    }

}
