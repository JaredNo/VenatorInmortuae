using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhase2 : MonoBehaviour
{
    //Movement Variables
    public Transform pt;
    public Rigidbody2D rb2;
    public float offset;
    public float speed;
    public float dist;
    public float RetreatTrig;
    public float ApproachTrig;

    //Shooting variables
    public Transform st;
    public float reloadTime;


    public void Start()
    {
        StartCoroutine(Shooty());    
    }

    // Update is called once per frame
    void Update()
    {
        //Targeting
        Vector3 difference = pt.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        //Distance check
        float xDist = (PlayerStats.PlayerPos[0] - transform.position.x) * (PlayerStats.PlayerPos[0] - transform.position.x);
        float yDist = (PlayerStats.PlayerPos[1] - transform.position.y) * (PlayerStats.PlayerPos[1] - transform.position.y);
        dist = Mathf.Sqrt(xDist + yDist);
    }

    private void FixedUpdate()
    {
        if(dist < RetreatTrig)
        {
            rb2.velocity = transform.up * -speed;
        }else if (dist > ApproachTrig)
        {
            rb2.velocity = transform.up * speed;
        }
        else
        { 
            rb2.velocity = transform.right * speed;
        }
        
    }

    IEnumerator Shooty()
    {
        while (this.isActiveAndEnabled)
        {
            yield return new WaitForSeconds(reloadTime);

            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("NecroBullet");
            bullet.transform.position = st.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }
}
