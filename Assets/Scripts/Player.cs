using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{ 
    public Image generalImage = null;
    public GameObject generalActiveEffect = null;
    public Image generalHealth = null;
    public Hand hand = null;
    public Board board = null;

    public int health = 20;
    public int essence = 1;
}