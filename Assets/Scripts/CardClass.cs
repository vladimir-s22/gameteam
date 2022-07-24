using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MUST READ: HOW TO REFER TO THIS CLASS?
// Just create Card 
// Then at some file just say: 
// public Card card;
// Now you can refer to that card.
// Debug.Log(faction+name)


[CreateAssetMenu(fileName = "New Card", menuName = "Card")]
public class Card : ScriptableObject {

	public new string name;
	public string description;

	public Sprite artwork;

	public int manaCost;
	public int attack;
	public int health;




    //true = Holy Roman Empire & false = Eltritch terror.
    public bool faction;

	public void Print () {
		Debug.Log(name + ": " + description + " The card costs: " + manaCost);
	}

    public int armour;
    public int heal;
    //IE like a one damage mushroom attack that unit releases when placed into the board.
    public int UnitsMagicDamage;
    //How many times unit can attack per turn.
    public int amountOfAttacksPerTurn;
    


    //Random cannot be done in Scriptable object?
    //Random attack amount.
    //Random rnd = new Random();
    //int randomAttack = rnd.Next(0, 6);

    //can be used to make custom if statements that give special abilities, but could be simpler to stict on defining those custom special things on this class statement.
    public int decision1;
    public int decision2;
    public int decision3;



}
