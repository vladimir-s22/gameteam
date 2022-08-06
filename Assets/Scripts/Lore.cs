using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Lore : MonoBehaviour {

    // Update is called once per frame
    public void BackToMainMenu() {
        SceneManager.LoadScene(1);
    }
}
