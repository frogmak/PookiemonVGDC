using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioLibrary : MonoBehaviour
{
    [Header("Music")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioClip musicClip;

    //[Header("Move SFX")]

    //[Header("Pookiemon SFX")]



    // Start is called before the first frame update
    void Start()
    {
        musicSource.clip = musicClip;
        musicSource.loop = true; 
        musicSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
