using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public Image generalImage = null;
    public Image generalHealth = null;
    public Hand hand = null;

    public int health = 20;
    public int essence = 1;

    public bool isActive = false;
}
