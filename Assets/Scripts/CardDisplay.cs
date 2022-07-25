using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardDisplay : MonoBehaviour
{
    public Card card;

    public Text nameText;
    public Text description;
    public Text faction;

    public Text cost;
    public Text health;
    public Text attack;

    public Image artwork;

    void Start()
    {
        nameText.text = card.name;
        description.text = card.description;
        faction.text = card.faction;

        cost.text = card.cost.ToString();
        health.text = card.health.ToString();
        attack.text = card.attack.ToString();

        artwork.sprite = card.artwork;
    }
}
