using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class ZombieGroan : MonoBehaviour
{
    public AudioClip[] Groans;
    public AudioSource m_audioSource;
    

    void Start()
    {
        m_audioSource = GetComponent<AudioSource>();
         
    }

    void Update()
    {
        if(isActiveAndEnabled)
        {
         int randomClip = Random.Range(0, Groans.Length);
         m_audioSource.clip = Groans[randomClip];
         m_audioSource.Play();  
        }
        else
        {
            return;
        }
    }
}
