using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Movement variables
    public Rigidbody2D rb2;
    public float speed;
    public Transform pt;

    //Transition variables
    public Animator FadeInAnimator, FadeOutAnimator;
    
    
    //Aiming Variables
    public float offset;

    //Shooty variables
    public GameObject bone;
    public Transform BulletSpawn;

    private void Start()
    {
        PlayerStats.ammo = 8;
        PlayerStats.health = 5;

        FadeInAnimator.SetTrigger("FadeInCalled");
    }

    private void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (Input.GetMouseButtonDown(0) && PlayerStats.ammo > 0 && PlayerStats.CanShoot == true)
        {
            PlayerStats.ModifyAmmo(-1);
            //Instantiate(bone, BulletSpawn.position, transform.rotation);

            FindObjectOfType<AudioManager>().Play("RibToss");


            GameObject bullet = ObjectPooler.SharedInstance.GetPooledObject("Player Bullet");
            bullet.transform.position = BulletSpawn.position;
            bullet.transform.rotation = transform.rotation * new Quaternion(0,0,180,0);
            bullet.SetActive(true);
        }
    }

    private void LateUpdate()
    {
        PlayerStats.PlayerPos[0] = transform.position.x;
        PlayerStats.PlayerPos[1] = transform.position.y;
        PlayerStats.PlayerPos[2] = transform.position.z;
    }




    // Update is called once per frame
    void FixedUpdate()
    {
        float i = Input.GetAxis("Horizontal");
        float e = Input.GetAxis("Vertical");

        rb2.velocity = new Vector2(i * speed * Time.deltaTime, e * speed * Time.deltaTime);
    }
}
