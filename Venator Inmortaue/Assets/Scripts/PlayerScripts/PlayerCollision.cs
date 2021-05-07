using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    public Rigidbody2D rb2;
    public Vector3 contactPoint;
    public bool CanCollide;
    public bool hasKey;

    public string SceneToLoad;

    public Animator animator;
    public Animator FadeOutAnimator;

    public GameObject destroyAfterKeyPickup;
    public GameObject spawnAfterKeyPickup;
    

    public void Start()
    {
        CanCollide = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && CanCollide)
        {
            animator.SetTrigger("HitEnemy");
            PlayerStats.ModifyHealth(-1);
            //Debug.Log(PlayerStats.health);
            StartCoroutine(InvincibilityFrames(1f));



            FindObjectOfType<AudioManager>().Play("PlayerHit");


            //This activates the contact particle
            contactPoint = collision.contacts[0].point;
            GameObject contactPart = ObjectPooler.SharedInstance.GetPooledObject("ContactParticle");
            contactPart.transform.position = contactPoint;
            contactPart.transform.rotation = Quaternion.identity;
            contactPart.SetActive(true);

            CanCollide = false;

        }

        if (collision.gameObject.tag == "Key" && CanCollide)
        {
            hasKey = true;
            Destroy(collision.gameObject);
            FindObjectOfType<AudioManager>().Play("NecromancerKey");
            destroyAfterKeyPickup.SetActive(false);
            spawnAfterKeyPickup.SetActive(true);

        }
    }//OnCollisionEnter2D




    public void OnCollisionStay2D(Collision2D collision)
    {
        if((collision.gameObject.tag == "Enemy" && CanCollide))
        {
            PlayerStats.ModifyHealth(-1);
            CanCollide = false;
            StartCoroutine(InvincibilityFrames(1f));
            animator.SetTrigger("HitEnemy");

            contactPoint = collision.contacts[0].point;
            GameObject contactPart = ObjectPooler.SharedInstance.GetPooledObject("ContactParticle");
            contactPart.transform.position = contactPoint;
            contactPart.transform.rotation = Quaternion.identity;
            contactPart.SetActive(true);

            FindObjectOfType<AudioManager>().Play("PlayerHit");
        }

    }

    public void Update()
    {
        if(PlayerStats.health == 0)
        {
            FadeOutAnimator.SetTrigger("FadeOutCalled");
            StartCoroutine(PlayerHasDied(2, SceneToLoad));
        }
    }

    IEnumerator PlayerHasDied(float i, string SceneToLoad)
    {
        
        yield return new WaitForSeconds(i);
        
        SceneManager.LoadScene(SceneToLoad);
    }

    




    


    IEnumerator InvincibilityFrames(float i)
    {
        yield return new WaitForSeconds(i);
        CanCollide = true;
    }

    IEnumerator LoadDeathScene()
    {
        //FadeOutAnimator.SetTrigger("FadeOutCalled");
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(SceneToLoad);
    }


}
