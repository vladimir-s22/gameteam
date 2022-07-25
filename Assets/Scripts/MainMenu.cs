using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
    using UnityEditor;
#endif


public class MainMenu : MonoBehaviour {
    
    public void startGame() {
        SceneManager.LoadScene(1);
    }

    public void quitGame() {
        #if UNITY_EDITOR
            EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}