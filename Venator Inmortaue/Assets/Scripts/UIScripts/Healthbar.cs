using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image image;
    public int ActiveThreshold;
    void Start()
    {
        image.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(PlayerStats.health < ActiveThreshold)
        {
            image.enabled = false;
        }
    }
}
