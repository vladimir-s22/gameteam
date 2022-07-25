using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Hand
{
    public Card[] cards = new Card[7];
    public Transform[] positions = new Transform[7];
    public string[] animNames = new string[3];
    public bool isActive;
}
