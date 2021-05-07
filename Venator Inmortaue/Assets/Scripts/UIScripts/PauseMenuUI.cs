using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseMenuUI : MonoBehaviour
{
    public int SceneToLoad;

    public void LoadSceneButton()
    {
        SceneManager.LoadScene(SceneToLoad);
    }

    

    public void QuitButton()
    {
        Application.Quit();
    }
}
