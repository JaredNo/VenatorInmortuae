using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickup : MonoBehaviour
{
    public SpriteRenderer sr;
    public float Delay;

    public float Speed;

    
    public float dist;
    private void OnEnable()
    {
        //sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 0);
        sr.sortingOrder = -1;
        sr.enabled = false;
        StartCoroutine(SpawnDelay(Delay));
    }//OnEnable


    //Keeps the pickup from appearing for a few seconds
    IEnumerator SpawnDelay(float i)
    {
        //while (sr.color.a == 0)
        //{
            yield return new WaitForSeconds(i);
            sr.enabled = true;
        sr.sortingOrder = 1;
            //sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, 1);
        //}
    }//SpawnDelay

    private void FixedUpdate()
    {
        float xDist = (PlayerStats.PlayerPos[0] - transform.position.x) * (PlayerStats.PlayerPos[0] - transform.position.x);
        float yDist = (PlayerStats.PlayerPos[1] - transform.position.y) * (PlayerStats.PlayerPos[1] - transform.position.y);
        dist = Mathf.Sqrt(xDist + yDist);

        //Debug.Log(dist);

        float interpolation = Speed * Time.fixedDeltaTime;
        Vector3 target = gameObject.transform.position;
        target.y = Mathf.Lerp(gameObject.transform.position.y, PlayerStats.PlayerPos[1], interpolation);
        target.x = Mathf.Lerp(gameObject.transform.position.x, PlayerStats.PlayerPos[0], interpolation);
        if(dist < 2f)
        {
            transform.position = target;
        }
    }//Update




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerStats.ModifyAmmo(1);
            GameObject pickupParticle = ObjectPooler.SharedInstance.GetPooledObject("PickupParticle");
            pickupParticle.transform.position = transform.position;
            pickupParticle.SetActive(true);
            gameObject.SetActive(false);
        }
    }//OnTriggerEnter2D
}
