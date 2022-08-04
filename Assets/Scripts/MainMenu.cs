using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

#if UNITY_EDITOR
    using UnityEditor;
#endif


public class MainMenu : MonoBehaviour {
    
    public AudioSource clickSoundMain;


    public void startGame() {
        SceneManager.LoadScene(2);
    }

    public void howToPlayScene() 
    {
        SceneManager.LoadScene(5);
    }

    public void loreScene() 
    {
        SceneManager.LoadScene(4);
    }

    public void quitGame() {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

 
    public void playSoundOnClick(){
        clickSoundMain.Play();
    }
}