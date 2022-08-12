using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackgroundMusic : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip[] playlist;
    int playlistOrder = 0;

    void Start()
    {
        audioSource = FindObjectOfType<AudioSource>();
        audioSource.loop = false;
    }

    public void Update () 
    {
        if (!audioSource.isPlaying) 
        {
            if(MuteScript.muted) 
            {
                audioSource.clip = GetCurrentClip();
                AudioListener.pause = MuteScript.muted;
            }
            else
            {
                audioSource.clip = GetNextClip();
                audioSource.Play();
            }
           
        }
    }

   

    private AudioClip GetCurrentClip() 
    {
        return playlist[playlistOrder];
    }


    private AudioClip GetNextClip() 
    {
        if(playlistOrder >= playlist.Length - 1) 
        {
            playlistOrder = 0;
        }
        else 
        {
            playlistOrder += 1;
        }
        return playlist[playlistOrder];
    }



    void Awake() 
    {
        DontDestroyOnLoad(transform.gameObject);
    }
}
