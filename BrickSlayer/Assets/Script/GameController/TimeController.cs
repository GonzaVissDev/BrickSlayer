using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeController :MonoBehaviour
{
    public float OmW = 120;
    float TimeInScene;
    public Text TimeText;
    public GameManager GM;

    // Start is called before the first frame update
    void Start()
    {
        OmW = 120;

    }

    // Update is called once per frame
    void Update()
    {

        if (GM.RdyToPlay == true)
        {
            TimeInScene = OmW - Time.time;

        if (TimeInScene > 0)
        {

            string minutes = ((int)TimeInScene / 60).ToString();
            string seconds = (TimeInScene % 60).ToString("f1");

            TimeText.text = minutes + ":" + seconds;
            //  Debug.Log("Minutos:" + minutes + "//" + "Segundos:" + seconds);



            if (Input.GetKeyDown(KeyCode.F))
            {
                ResetTime();
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
