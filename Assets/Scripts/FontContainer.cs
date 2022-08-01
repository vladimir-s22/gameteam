using UnityEngine;

public class FontContainer : MonoBehaviour
{
    public static FontContainer instance { get; private set; }

    public Sprite[] HealthNumbers = new Sprite[21];
    public Sprite[] DamageNumbers = new Sprite[21];
    public Sprite[] RedGlowNumbers = new Sprite[21];
    public Sprite[] CostNumbers = new Sprite[10];

    private void Awake()
    {
        if (instance != null && instance != this)
        { Destroy(this); }
        else
        { instance = this; }
    }
}
