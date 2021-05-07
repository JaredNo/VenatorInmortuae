using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    private int parts = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player" && parts == 1)
        {
            parts++;
            FindObjectOfType<AudioManager>().Play("P1");
        }
        else if (collision.gameObject.tag == "Player" && parts == 2)
        {
            parts++;
            FindObjectOfType<AudioManager>().Play("P2");
        }
        else if (collision.gameObject.tag == "Player" && parts == 3)
        {
            parts++;
            FindObjectOfType<AudioManager>().Play("P3");
        }
        else if (collision.gameObject.tag == "Player" && parts == 4)
        {
            parts++;
            FindObjectOfType<AudioManager>().Play("P4");
        }
        else if (collision.gameObject.tag == "Player" && parts == 5)
        {

            FindObjectOfType<AudioManager>().Play("P5");
            parts = 1;
        }
    }

}


