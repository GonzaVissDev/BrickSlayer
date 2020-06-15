using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public GameObject ButtonCanvas;
    public GameObject ExitPanel;
    // Start is called before the first frame update
    void Start()
    {
        ButtonCanvas.SetActive(true);
        ExitPanel.SetActive(false);
        
    }


    public void EnterDungeon()
    {
        Application.LoadLevel("Level1-1");

    }


    public void ExitPanelOpen()
    {
        ButtonCanvas.SetActive(false);
        ExitPanel.SetActive(true);

    }
    public void ExitPanelClose()
    {
        ButtonCanvas.SetActive(true);
        ExitPanel.SetActive(false);

    }

    public void ExitApllicaciont ()
    {
        ExitApllicaciont();

    }




}
