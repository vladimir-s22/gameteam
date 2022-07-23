using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour {
    
    public void LetTheGamesBegin() {
        // starts asyncronous loading of the next screen, so there won't be any awkward waiting period.
        // Loads the main game scene which has index 1 on build settings.
        StartCoroutine(LoadYourAsyncScene(1));   
    }

    IEnumerator LoadYourAsyncScene(int indexOfScreen) {
        // The Application loads the Scene in the background as the current Scene runs.
        // This is particularly good for creating loading screens.
        // You could also load the Scene by using sceneBuildIndex. In this case Scene2 has
        // a sceneBuildIndex of 1 as shown in Build Settings.

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(indexOfScreen);

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone) {
            yield return null;
        }
    }

    public void QuitGame() {
        Application.Quit();
    }
}