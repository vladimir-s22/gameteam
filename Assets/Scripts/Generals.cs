using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Card", menuName = "GameTeam/Generals")]
public class Generals : ScriptableObject
{
    public string generalTitle;
    public string generalDescription;
    public string generalFaction;

    public Sprite design;
    
    public int health;
    


}
