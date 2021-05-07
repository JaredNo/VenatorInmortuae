using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{

    public string[] SceneToLoad;

    public Animator FadeInAnimator, FadeOutAnimator;

    public void Start()
    {
        FadeInAnimator.SetTrigger("FadeInCalled");
    }


    public void OnMenuButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        FadeOutAnimator.SetTrigger("FadeOutCalled");
        StartCoroutine(LoadAfterDelay(2f, SceneToLoad[0]));
        //SceneManager.LoadScene(SceneToLoad[0]);
    }

    public void OnRetryButton()
    {
        FindObjectOfType<AudioManager>().Play("Click");
        FadeOutAnimator.SetTrigger("FadeOutCalled");
        StartCoroutine(LoadAfterDelay(2f, SceneToLoad[1]));
        //SceneManager.LoadScene("Graveyard");
    }

    IEnumerator LoadAfterDelay(float i, string SceneToLoad)
    {
        yield return new WaitForSeconds(i);
        SceneManager.LoadScene(SceneToLoad);
    }
}
