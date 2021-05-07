using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class BoneCounter : MonoBehaviour
{
    public Sprite[] bones;
    public Image Im;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void Update()
    {
        int i = PlayerStats.ammo;

        switch (i)
        {
            case 8:
                Im.sprite = bones[8];
                break;
            case 7:
                Im.sprite = bones[7];
                break;
            case 6:
                Im.sprite = bones[6];
                break;
            case 5:
                Im.sprite = bones[5];
                break;
            case 4:
                Im.sprite = bones[4];
                break;
            case 3:
                Im.sprite = bones[3];
                break;
            case 2:
                Im.sprite = bones[2];
                break;
            case 1:
                Im.sprite = bones[1];
                break;
            case 0:
                Im.sprite = bones[0];
                break;
        }
    }


}
