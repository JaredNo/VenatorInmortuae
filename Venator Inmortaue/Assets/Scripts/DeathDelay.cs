using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathDelay : MonoBehaviour
{
    public float Delay;
    public float i = 0;

    public void OnEnable()
    {
        i = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        i += Time.deltaTime;

        if(i > Delay)
        {
            gameObject.SetActive(false);
        }
    }
}
