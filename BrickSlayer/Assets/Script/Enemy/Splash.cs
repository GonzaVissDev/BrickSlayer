using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    public float Time;
    public Sprite[] Tinta;
    private SpriteRenderer sp;
    // Start is called before the first frame update
    void Start()
    {

        int RandomNumber = Random.Range(0, Tinta.Length);

        sp = GetComponent<SpriteRenderer>();
        sp.sprite = Tinta[RandomNumber];
        anim = GetComponent<Animator>();
        StartCoroutine(Vanish());
        
    }

  IEnumerator Vanish ()
    {
        yield return new WaitForSeconds(Time);
        anim.Play("Off");
        Destroy(this.gameObject,1f);
    }
}
