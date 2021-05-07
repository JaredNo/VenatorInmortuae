using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPhaseOne : MonoBehaviour
{
    //Movement variables
    public Transform pt;
    public Rigidbody2D rb;
    public float speed;
    public float offset;

    public BossPhase2 phase2;

    public Transform st;
    public float reloadTime;
    public GameObject bullet;

    public void Start()
    {
        StartCoroutine(Shooty());
        
    }

    public void Update()
    {
        Vector3 difference = pt.position - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if(BossStats.health < 16)
        {
            phase2.enabled = true;
            this.enabled = false;
        }
    }

    public void FixedUpdate()
    {
        rb.velocity = transform.up * speed;


    }

    public void LateUpdate()
    {
        
    }


    IEnumerator Shooty()
    {
        while(this.enabled == true)
        {
            yield return new WaitForSeconds(reloadTime);

            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("NecroBullet");
            bullet.transform.position = st.position;
            bullet.transform.rotation = transform.rotation;
            bullet.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player Bullet")
        {
            BossStats.ModifyHealth(-1);
        }
    }
}
