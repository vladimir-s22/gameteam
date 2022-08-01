using UnityEngine;

public class FontContainer : MonoBehaviour
{
    public static FontContainer instance;

    [SerializeField] public Sprite[] HealthNumbers = new Sprite[21];
    [SerializeField] public Sprite[] DamageNumbers = new Sprite[21];
    [SerializeField] public Sprite[] RedGlowNumbers = new Sprite[21];
    [SerializeField] public Sprite[] CostNumbers = new Sprite[10];
}
