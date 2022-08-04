using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;



public class StartingScreenScript : MonoBehaviour {
    public void ContinueToMainMenu() {
        SceneManager.LoadScene(1);
    }
}
