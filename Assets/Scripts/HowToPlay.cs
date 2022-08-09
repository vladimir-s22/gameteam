using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HowToPlay : MonoBehaviour
{
    public AudioSource clickSoundMain;

    public void backToMenu() 
    {
        SceneManager.LoadScene(1);
    }

    public void playSoundOnClick()
    {
        clickSoundMain.Play();
    }
    void Awake()
    {
        DontDestroyOnLoad(clickSoundMain);
    }
}
