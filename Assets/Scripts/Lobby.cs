using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Lobby : MonoBehaviour
{
    public void back()
    {
        SceneManager.LoadScene(1);
    }

    public Button player1;
    public Button player2;

    public bool player1Selected;  // Checks if player 1 has confirmed the selection of their player
    public bool player2Selected;  // Checks if player 2 has selected a character

    void Start() 
    {
        player1.onClick.AddListener(ConfirmSelection1);     
        player2.onClick.AddListener(ConfirmSelection2);
    }

    void CheckSelections()                // Checks if both players have selected their characters
    {
        if (player1Selected && player2Selected)                        
        {
            SceneManager.LoadScene(2);      
        }
    }
    void ConfirmSelection1()                 //This confirms the selection of player 1 
    {
        player1Selected = true;
        CheckSelections();
    }

    void ConfirmSelection2()                //This confirms the selection of player 2
    {
        player2Selected = true;
        CheckSelections();
    }

  


}
