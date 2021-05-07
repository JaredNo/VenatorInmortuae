using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CreditSceneUI : MonoBehaviour
{
    public string SceneToLoad;
    public void MainMenuButton()
    {
       // FindObjectOfType<AudioManager>().Play("Click");
        SceneManager.LoadScene(SceneToLoad);
    }




    public void Update()
    {
        if (Input.anyKeyDown)
        {
            FindObjectOfType<AudioManager>().Play("Click");
            CreditRoller();
        }
    }




    public GameObject[] Panels;
    private int CurrentSlide = 0;
    private int NextSlide = 1;

    public void CreditRoller()
    {
        Panels[CurrentSlide].SetActive(false);
        CurrentSlide = NextSlide;
        if(CurrentSlide == 5)
        {
            NextSlide = 0;
        }
        else
        {
            NextSlide += 1;
        }
        
        Panels[CurrentSlide].SetActive(true);
    }
}
