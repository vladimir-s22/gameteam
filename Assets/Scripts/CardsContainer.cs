using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardsContainer : MonoBehaviour
{
    public static CardsContainer instance;

    [SerializeField] public List<CardData> RomanCards = new List<CardData>();
    [SerializeField] public List<CardData> EldritchCards = new List<CardData>();

    [SerializeField] public GameObject EldritchUnitPrefab;
    [SerializeField] public GameObject EldritchSpellPrefab;

    [SerializeField] public GameObject RomanUnitPrefab;
    [SerializeField] public GameObject RomanSpellPrefab;
}
