using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverButton : MonoBehaviour
{
    public bool IsMenuButton, IsRetryButton;

    public GameOverScreen GOS;

    private void OnMouseDown()
    {
        if (IsMenuButton)
        {
            GOS.OnMenuButton();
        }else if (IsRetryButton)
        {
            GOS.OnRetryButton();
        }
    }
}
