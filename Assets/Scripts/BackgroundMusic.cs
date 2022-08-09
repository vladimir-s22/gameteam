using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour 
{
    private static BackgroundMusic backgroundMusic;
    private AudioSource audioSource;
    public AudioClip[] playlist;
    public bool randomPlay = false;
    int playlistOrder = 0;

    void Start () 
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
    }


    void Update () 
    {
        if (!audioSource.isPlaying) 
        {
            if(randomPlay == true) 
            {
                audioSource.clip = GetRandomClip();
                audioSource.Play();
            }
            else 
            {
                audioSource.clip = GetNextClip();
                audioSource.Play();
            }
            
        }
    }

    private AudioClip GetRandomClip()
    {
        return playlist[Random.Range(0, playlist.Length)];
    }

    private AudioClip GetNextClip() 
    {
        if(playlistOrder >= playlist.Length - 1) 
        {
            playlistOrder = 1;
        }
        else 
        {
            playlistOrder += 1;
        }
        return playlist[playlistOrder];
    }



    void Awake() 
    {
        if (backgroundMusic == null) 
        {
            backgroundMusic = this;
            DontDestroyOnLoad(backgroundMusic);
        }
        else 
        {
            Destroy(gameObject);
        }
    }
}
