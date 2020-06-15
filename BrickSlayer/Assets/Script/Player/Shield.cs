using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour
{
    private Animator Anim;

    private void Start()
    {
        Anim = GetComponent<Animator>();
    }

    public void ShieldUp()
    {
        Anim.SetBool("ShieldUp",true);
    }

}
