using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
    public Animator camAnim;
    public bool ShouldPlay;

    public void CamShake()
    {
        
        if(ShouldPlay)
            camAnim.SetTrigger("Shake");
    }
}
