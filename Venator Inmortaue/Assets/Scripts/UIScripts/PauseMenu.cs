using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool IsPaused;
    public GameObject PauseMenuUI;
    public string SceneToLoad;


    public void Start()
    {
        PauseMenuUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
                //Camera.main.GetComponent<AudioSource>().UnPause();
               // AudioListener.pause = false;
            }
            else
            {
                Pause();
                //Camera.main.GetComponent<AudioSource>().Pause();
               // AudioListener.pause = true;
            }
        }
    }

    public void Pause()
    {
        PauseMenuUI.SetActive(true);
        Time.timeScale = 0;
        IsPaused = true;
        PlayerStats.CanShoot = false;
    }

    public void Resume()
    {
        PauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        IsPaused = false;
        PlayerStats.CanShoot = true;
    }

    
    /*
    public void LoadSceneButton()
    {
        Debug.Log("MenuClicked");
        SceneManager.LoadScene("TitleScreen");
        Time.timeScale = 1;
        AudioListener.pause = false;
        
    }
    */

    public void MenuButton()
    {
        SceneManager.LoadScene("TitleScreen");
    }






    public void QuitButton()
    {
        Debug.Log("QuitClicked");
        Application.Quit();
    }
}
