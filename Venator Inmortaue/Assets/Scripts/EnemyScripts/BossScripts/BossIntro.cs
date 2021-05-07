using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIntro : MonoBehaviour
{
    //Player variables
    public PlayerController playerController;
    public Rigidbody2D prb;

    //Boss variables
    public BossPhaseOne bp1;

    //Self variables
    public BoxCollider2D box;
    public BossOutro outro;


    public void Start()
    {
        BossStats.health = 30;
    }

    public void Update()
    {
        if(BossStats.health <= 0)
        {
            outro.enabled = true;
            this.enabled = false;
        }
    }






    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            FindObjectOfType<AudioManager>().Play("FindingN");
            StartCoroutine(Intro(7.25f));
        }
    }

    IEnumerator Intro(float i)
    {
        box.enabled = false;
        playerController.enabled = false;
        prb.velocity = new Vector2(0, 0);
        yield return new WaitForSeconds(i);
        playerController.enabled = true;
        bp1.enabled = true;
        
        
    }
}
