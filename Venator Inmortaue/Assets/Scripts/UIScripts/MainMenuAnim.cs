using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuAnim : MonoBehaviour
{
    public Animator animator;
    public string AnimToPlay;

    public void Start()
    {
        Debug.Log("Title screen loaded");
    }
    public void OnMouseDown()
    {
        //Debug.Log("ButtonClicked");
        animator.SetTrigger(AnimToPlay);
    }
}
