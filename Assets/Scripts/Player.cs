using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    private Hand _hand;
    private Board _board;
    private General _general;

    private Deck _deck = new Deck();

    private int _essence = 1;

    private void Awake()
    {
        _hand = gameObject.GetComponentInChildren<Hand>();
        _board = gameObject.GetComponentInChildren<Board>();
        _general = gameObject.GetComponentInChildren<General>();
    }

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
        return _hand;
    }

    public Board GetBoard()
    {
        return _board;
    }

    public General GetGeneral()
    {
        return _general;
    }

}