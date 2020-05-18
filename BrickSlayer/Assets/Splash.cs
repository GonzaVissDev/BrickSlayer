using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash : MonoBehaviour
{
    private Animator anim;
    public float Time;
    // Start is called before the first frame update
    void Start()
    {
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
