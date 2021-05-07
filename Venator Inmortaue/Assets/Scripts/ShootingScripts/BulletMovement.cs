using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public Rigidbody2D rb2;
    public float scaler;
    public GameObject ammoPickup;
    public GameObject ImpactParticles;
    public Transform PickupSpawnPoint;
    public AudioSource impact;

    private ScreenShake screenShake;
    // Start is called before the first frame update
    public void OnEnable()
    {
        screenShake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ScreenShake>();
        rb2.velocity = transform.up * scaler;
    }

    //please make possible for collision enter
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag != "Ammo" && collision.gameObject.tag != "Player")
        {
            screenShake.CamShake();
            GameObject impPart = ObjectPooler.SharedInstance.GetPooledObject("ImpactParticle");
            impPart.transform.position = transform.position;
            impPart.SetActive(true);

            GameObject AmmoPickup = ObjectPooler.SharedInstance.GetPooledObject("Ammo");
            AmmoPickup.transform.position = transform.position;
            AmmoPickup.transform.rotation = Quaternion.identity;
            AmmoPickup.SetActive(true);


            
            gameObject.SetActive(false);
        }
    }


}
