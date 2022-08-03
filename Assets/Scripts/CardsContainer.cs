using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsContainer : MonoBehaviour
{
    public static CardsContainer instance { get; private set;}

    [SerializeField] private List<CardData> RomanCards = new List<CardData>();
    [SerializeField] private List<CardData> EldritchCards = new List<CardData>();

    [SerializeField] private GameObject EldritchUnitPrefab;
    [SerializeField] private GameObject EldritchSpellPrefab;

    [SerializeField] private GameObject RomanUnitPrefab;
    [SerializeField] private GameObject RomanSpellPrefab;

    private void Awake()
    {
        if (instance != null && instance != this)
        { Destroy(this); }
        else
        { instance = this; }
    }

    public List<CardData> GetEldritchCards()
    {
        return EldritchCards;
    }

    public List<CardData> GetRomanCards()
    {
        return RomanCards;
    }

    public GameObject GetPrefab(CardData cardData)
    {
        if (cardData.cardFaction == "Holy Roman Empire")
        {
            if (cardData.isSpell)
            {
                return RomanSpellPrefab;
            } else
            {
                return RomanUnitPrefab;
            }
        } else
        {
            if (cardData.isSpell)
            {
                return EldritchSpellPrefab;
            }
            else
            {
                return EldritchUnitPrefab;
            }
        }
    }
}
