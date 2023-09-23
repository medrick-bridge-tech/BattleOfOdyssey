using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip[] deathSounds;
    public AudioClip[] DeathSounds => deathSounds;
    
    private void Awake()
    {
        if (FindObjectsOfType<Music>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);    
        }
    }
}
