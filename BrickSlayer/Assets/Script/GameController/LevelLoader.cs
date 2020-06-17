using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    [Tooltip("Tiempo que demora en cambiar la escena")]
    public float transitionTime;

    [Tooltip("Escribir como se llama la proxima escena a cargar.")]
    public string index;
    private Animator Transition;


    private void Start()
    {
       Transition = GetComponent<Animator>();
    }

    public void LoadNextTextLevel()
    {
       StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1 ));
    }

    public void ResetLevel()
    {
        SceneManager.LoadScene("MainMenu");
    }


    IEnumerator LoadLevel(int levelIndex)
    {
        Transition.SetTrigger("Start");
        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
