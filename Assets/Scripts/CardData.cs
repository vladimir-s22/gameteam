using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "GameTeam/Card")]
public class CardData : ScriptableObject
{
    public string cardTitle;
    public string cardDescription;
    public string cardFaction;

    public int cost;
    public int health;
    public int damage;
    public int numberInDeck;

    public Sprite cardImage;
    
    public bool isSpell = false;
    public bool isRanged = false;

    public int thorns = 0;
    public int armour = 0;
    public int spellPower = 0;

    public string spellType;
    public string spellTarget;
    public string summonUnit;
}