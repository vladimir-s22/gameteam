using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void quiteGame() 
    {
        SceneManager.LoadScene(0);
    }

    public void endTurn() 
    {
    }
}
