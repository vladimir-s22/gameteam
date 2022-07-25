using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hand
{
    public Card[] cards = new Card[7];
    public GameObject cardArea = null;
    public string[] animNames = new string[3];
    public bool isActive;
}
