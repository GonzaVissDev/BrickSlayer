using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Componentes del jugador.
    public int Life = 3;
    public Text HeartText;
    public GameObject Player;
    public static GameManager instance = null;

    private GameObject ClonePlayer;

    //Componentes del Juego.
    public float ResetDelay = 1f;
    public Text GameCondition;
    private ReadyText IntroText;
    public string NextLvl;
    public float GlobalSpeed;

    //Cree un booleano "RdyToPlay" para verificar en los script "Ball y TimeController" si el juego ya es @Jugable@
    public bool RdyToPlay = false;



    // Start is called before the first frame update
    void Start()
    {
        IntroText = GetComponent<ReadyText>();
        GameObject Objecttext = GameObject.FindGameObjectWithTag("IntroText");
        if (Objecttext != null) IntroText = Objecttext.GetComponent<ReadyText>();
        SetUpGame();
        IntroText.rdyState = ReadyText.ReadyState.Start;

        //falta testear el tiempo y la velocidad que aumenta..
       
       //InvokeRepeating("SpeedUp", 0.0f, 10f);


    }

    public void SpeedUp()
    {
        Time.timeScale+= GlobalSpeed;
    }

    public void SetUpGame()
    {

        Time.timeScale = 1f;
        ClonePlayer= Instantiate(Player, transform.position, Quaternion.identity )as GameObject;
        Time.timeScale = 1f;

    }

    public void WinGame()
    {
        GameCondition.text = "Nivel Completado";
        GameCondition.enabled = true;
        Time.timeScale = .25f;
        Invoke("NextLevel", ResetDelay);
        Debug.Log("Ganaste");
    }

    public void LoseGame()
    {
        GameCondition.text = "Perdiste";
        GameCondition.enabled = true;
        Time.timeScale = 0f;
        Invoke("ResetGame", 1f);

    }

    public void ResetGame()
    {
        Debug.Log("Se reinicia el nivel");
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);

        //Falta cargar animacion de carga de pantalla.
    }

    public void NextLevel()
    {
        Application.LoadLevel(NextLvl);

     
    }


    public void LoseLife(){
        Life--;
        HeartText.text = "Vidas:" + Life;
        //Falta aGregar Animacion de muerte
        Object[] PlayerInScne = GameObject.FindGameObjectsWithTag("Player");


        foreach (GameObject x in PlayerInScne)
        {
            Destroy(x.gameObject);
        }

        if (Life<=0)
        {
            LoseGame();
        }

        Invoke("SetUpGame", ResetDelay);

    }




}
