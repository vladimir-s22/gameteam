using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "Generals")]
public class Generals : ScriptableObject
{
    public new string name;
    public string description;

    public Sprite design;

    public int manacost;
    public int attack;
    public int health;
    


}
