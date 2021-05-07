using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TitleScreen : MonoBehaviour
{
    //This is the level that is loaded
    public string GraveyardScene;

    //This is the credits scene
    public string CreditsScene;

    //These are references to the scene transition animators
    public Animator FadeInAnimator, FadeOutAnimator;

    public void OnEnable()
    {
        Time.timeScale = 1;
        //This plays a scene transition when the title screen is loaded
        FadeInAnimator.Play("FadeIn");
        Debug.Log("Title screen has been loaded");
    }

    

    //This method is called when the play button is pressed
    public void PlayButton()
    {
        
        FindObjectOfType<AudioManager>().Play("Click");
        FadeOutAnimator.SetTrigger("FadeOutCalled");
        StartCoroutine(LoadAfterDelay(2.5f, GraveyardScene));

        Debug.Log("ButtonClicked");
    }

    //this method is called when the credits button is pressed
    public void CreditsButton()
    {
        
        FindObjectOfType<AudioManager>().Play("Click");
        FadeOutAnimator.SetTrigger("FadeOutCalled");
        StartCoroutine(LoadAfterDelay(2f, CreditsScene));

        Debug.Log("ButtonClicked");

    }

    //This method is called when the quit button is pressed
    public void QuitButton()
    {
        
        FindObjectOfType<AudioManager>().Play("Click");
        Application.Quit();

        Debug.Log("ButtonClicked");
    }

    //this coroutine is used to ensure that the scene transitions have time to play before the levels are loaded
    IEnumerator LoadAfterDelay(float i, string SceneToLoad)
    {
        yield return new WaitForSeconds(i);
        SceneManager.LoadScene(SceneToLoad);
    }
}
