using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    public Image GeneralImage;
    public Image PlayerHealth;

    public Hand PlayerHand = new Hand();
    public Board PlayerBoard = new Board();
    public Deck PlayerDeck = new Deck();

    public string PlayerName;

    private int _essence = 1;

    public void IncrementEssence()
    {
        _essence++;
    }

    public void DecrementEssence()
    {
        _essence--;
    }

    public int GetEssence()
    {
        return _essence;
    }

    public Hand GetHand()
    {
        return PlayerHand;
    }

    public Board GetBoard()
    {
        return PlayerBoard;
    }

    public Deck GetPlayerDeck()
    {
        return PlayerDeck;
    }
}