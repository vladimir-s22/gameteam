using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartingScreenScript : MonoBehaviour 
{
    public AudioSource clickSoundMain;

    public void ContinueToMainMenu() 
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
