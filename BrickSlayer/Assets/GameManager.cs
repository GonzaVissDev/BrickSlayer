using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int Life = 3;
    public float ResetDelay = 1f;
    public Text HeartText;
    public Text GameCondition;
    public GameObject Player;
    public static GameManager instance = null;

    private GameObject ClonePlayer;
    
    // Intanciar todos los objetos





    // Start is called before the first frame update
    void Start()
    {
        SetUpGame();
    
    }


    public void SetUpGame()
    {
      ClonePlayer= Instantiate(Player, transform.position, Quaternion.identity )as GameObject;

    }

    public void WinGame()
    {
        GameCondition.text = "Ganaste";
        GameCondition.enabled = true;
        Time.timeScale = .25f;
        Invoke("ResetGame", ResetDelay);
        Debug.Log("Ganaste");
    }

    public void LoseGame()
    {
        GameCondition.text = "Perdiste";
        GameCondition.enabled = true;
        Debug.Log("Perdiste");
        //Falta activar un panel de reinicio de nivel o volver al menu.
    }

    public void ResetGame()
    {
        Debug.Log("Se reinicia el nivel");
        Time.timeScale = 1f;
        Application.LoadLevel(Application.loadedLevel);

        //Falta cargar animacion de carga de pantalla.
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
