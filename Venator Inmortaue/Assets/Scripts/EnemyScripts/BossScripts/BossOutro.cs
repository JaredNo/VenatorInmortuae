using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BossOutro : MonoBehaviour
{
    //Boss variables
    public BossPhase2 bp2;
    public Rigidbody2D rb2;

    public GameObject DeathParticle;
    
    public Animator FadeOut;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("Ending");
        bp2.enabled = false;
        rb2.velocity = new Vector2(0, 0);
        StartCoroutine(DeathScene(13.1f, 1.5f));
    }

    IEnumerator DeathScene(float FirstDelay, float SecondDelay)
    {
        DeathParticle.SetActive(true);
        yield return new WaitForSeconds(FirstDelay);
        FadeOut.SetTrigger("FadeOutCalled");
        yield return new WaitForSeconds(SecondDelay);
        SceneManager.LoadScene("TitleScreen");
    }
    
}
