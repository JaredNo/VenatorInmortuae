using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingDetector : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            PlayerStats.CanShoot = false;
        }
        else
        {
            PlayerStats.CanShoot = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Wall")
        {
            PlayerStats.CanShoot = true;
        }
    }


}
