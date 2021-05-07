using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class telePlayer : MonoBehaviour
{
    public Transform destination;
    public GameObject player;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            player.transform.position = destination.transform.position;
        } else if (collision.tag == "Player Bullet")
        {
            collision.transform.position = player.transform.position;
        } else if (collision.tag == "Enemy")
        {
            collision.transform.position = transform.position;
        }
    }
}
