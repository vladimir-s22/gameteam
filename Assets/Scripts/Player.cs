using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Hand _hand;
    [SerializeField] private Board _board;
    [SerializeField] private General _general;
    public Deck Deck;

    private int _essence = 1;

    public void IncrementEssence()
    {
        if (_essence <= 10)
            _essence++;
    }

    public void DecrementEssence()
    {
        if (_essence >= 0)
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

    public void Initialize()
    {
        Deck = new Deck();
        _hand = gameObject.GetComponentInChildren<Hand>();
        _board = gameObject.GetComponentInChildren<Board>();
        _general = gameObject.GetComponentInChildren<General>();
    }
}