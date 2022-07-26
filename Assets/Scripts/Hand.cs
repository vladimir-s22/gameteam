using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hand
{
    public GameObject cardArea = null;

    public Card[] cards = new Card[7];
    
    public string[] animNames = new string[3];
    public bool isActive;
}
