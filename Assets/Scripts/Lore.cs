using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lore : MonoBehaviour 
{
    public AudioSource clickSoundMain;

    // Update is called once per frame
    public void BackToMainMenu() 
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
