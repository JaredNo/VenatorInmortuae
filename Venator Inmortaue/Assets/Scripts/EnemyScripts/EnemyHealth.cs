using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    

    public void Start()
    {
        
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player Bullet")
        {
            FindObjectOfType<AudioManager>().Play("ZombieHit");
            health -= 1;
        }

        if(health == 0)
        {
            gameObject.SetActive(false);
            
        }
    }


}
