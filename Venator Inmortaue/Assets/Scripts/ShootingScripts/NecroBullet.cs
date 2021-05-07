using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NecroBullet : MonoBehaviour
{
    public Rigidbody2D rb2;
    public float speed;

    public Animator PA;
    void OnEnable()
    {
        rb2.velocity = transform.up * speed;
        PA = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            PlayerStats.ModifyHealth(-1);

            GameObject impPart = ObjectPooler.SharedInstance.GetPooledObject("ImpactParticle");
            impPart.transform.position = transform.position;
            impPart.SetActive(true);

            PA.SetTrigger("HitEnemy");
        }

        gameObject.SetActive(false);
    }

    public void FixedUpdate()
    {
        rb2.velocity = transform.up * speed;
    }


}
