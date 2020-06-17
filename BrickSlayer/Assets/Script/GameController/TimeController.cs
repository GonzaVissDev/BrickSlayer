using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController :MonoBehaviour
{
   [Tooltip("Tiempo Total del Reloj")]
    public float OmW = 120;
    float TimeInScene;
    public Text TimeText;
    public GameManager GM;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
        OmW = 120;
    }

    // Update is called once per frame
    void Update()
    {

        if (GM.RdyToPlay == true)
        {
            TimeInScene = OmW - Time.timeSinceLevelLoad;

        if (TimeInScene > 0)
        {

            string minutes = ((int)TimeInScene / 60).ToString();
            string seconds = (TimeInScene % 60).ToString("f0");

            TimeText.text = minutes + ":" + seconds;
                //  Debug.Log("Minutos:" + minutes + "//" + "Segundos:" + seconds);
                if (TimeInScene < 25f){

                    FindObjectOfType<AudioManager>().Play("Poco_Tiempo");
                    anim.Play("Hurry");

        }
            }
            else
            GM.LoseGame();
    }
        
    }

    public void StopTime(bool FreezeAll)
    {
        if (FreezeAll == true)
        {
            Time.timeScale = 0;
        }
        else
            Time.timeScale = 1;
    }

    private void ResetTime()
    {
        TimeInScene = 0;
    }
}
