using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Componentes del jugador.
    private int Life = 3;
    public GameObject[] Corazones;

    public GameObject ParticleWin;
    public GameObject Player;
    public static GameManager instance = null;

    private GameObject ClonePlayer;

    private bool Winthegame;
    //Componentes del Juego.
    private LevelLoader lvlControler;
    public float ResetDelay = 1f;
    public Text GameCondition;
    public Text GameCondition_Shadow;
    private ReadyText IntroText;


    //Cree un booleano "RdyToPlay" para verificar en los script "Ball y TimeController" si el juego ya es @Jugable@
    public bool RdyToPlay = false;


    void Start()
    {
        //Obtengo los componentes de cada Variable.
        IntroText = GetComponent<ReadyText>();
        lvlControler = GetComponentInChildren<LevelLoader>();

        GameObject Objecttext = GameObject.FindGameObjectWithTag("IntroText");
        if (Objecttext != null) IntroText = Objecttext.GetComponent<ReadyText>();
        Winthegame = false;
        SetUpGame();

        IntroText.rdyState = ReadyText.ReadyState.Start;
        GameCondition.enabled = false;
        GameCondition_Shadow.enabled = false;

    }


    //Metodo configuracion inicial del juego.
    public void SetUpGame()
    {
        Time.timeScale = 1f;
        ClonePlayer= Instantiate(Player, transform.position, Quaternion.identity )as GameObject;

    }

    public void WinGame()
    {
        if(Winthegame == false)
        {
            FindObjectOfType<AudioManager>().Play("Ganaste");
            Instantiate(ParticleWin,new Vector3(0,0,0), transform.rotation);
            Winthegame = true;
        }
        
        GameCondition.text = "Nivel Completado";
        GameCondition_Shadow.text = "Nivel Completado";
        GameCondition.enabled = true;
        GameCondition_Shadow.enabled = true;
      //  Time.timeScale = .25f;

        //Borramos al jugador para evitar Bugs
        Object[] PlayerInScne = GameObject.FindGameObjectsWithTag("Player");

        foreach (GameObject x in PlayerInScne)
        {
            Destroy(x.gameObject);
        }


        lvlControler.LoadNextTextLevel();
        
       
    }

    public void LoseGame()
    {
        //Falta mandarlo al menu principal.
        GameCondition.text = "Fin de la Partida";
        GameCondition_Shadow.text = "Fin de la Partida";
        GameCondition.enabled = true;
        GameCondition_Shadow.enabled = true;
        Invoke("ResetGame", 1.5f);
 
    }

    public void ResetGame()
    {

        Time.timeScale = 1f;
        lvlControler.ResetLevel();
    }



    public void LoseLife(){

        Life--;
        if(Life > -1)
        {
            Corazones[Life].GetComponent<Animator>().SetBool("Destroy", true);
        }

        //Falta aGregar Animacion de muerte
        Object[] PlayerInScne = GameObject.FindGameObjectsWithTag("Player");
       // Object[] ObjectInScne = GameObject.FindGameObjectsWithTag("Sword");


        foreach (GameObject x in PlayerInScne)
        {
            Destroy(x.gameObject);
        }
       /* foreach (GameObject x in ObjectInScne)
        {
            Destroy(x.gameObject);
        }

*/        if (Life<= -1)
        {
            LoseGame();
            
        }

        Invoke("SetUpGame", ResetDelay);

    }

}
