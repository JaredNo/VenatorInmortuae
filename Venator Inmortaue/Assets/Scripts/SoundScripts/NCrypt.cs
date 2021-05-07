using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NCrypt : MonoBehaviour
{
    public int num = 0;

    //Player variables
    public PlayerController playerController;
    public Rigidbody2D prb;



    void OnTriggerEnter2D(Collider2D collision)
    {
        if (num == 0 && collision.gameObject.tag == "Player")
        {
            num++;
            FindObjectOfType<AudioManager>().Play("HeroEnterC");
            StartCoroutine(Intro(7.25f));
        }
    }

    IEnumerator Intro(float i)
    {
        playerController.enabled = false;
        prb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(i);
        playerController.enabled = true;
    }


}

