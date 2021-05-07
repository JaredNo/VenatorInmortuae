using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Necromancer : MonoBehaviour
{

    //Player variables
    public PlayerController playerController;
    public Rigidbody2D prb;

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("Test");
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("NecromancerB");
             Destroy(gameObject);
           
            
        }
    }




}
