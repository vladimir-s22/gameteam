using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    static public GameController instance = null;

    public Deck playerADeck = new Deck();
    public Deck playerBDeck = new Deck();

    public Hand playerAHand = new Hand();
    public Hand playerBHand = new Hand();

    public List<CardData> cards = new List<CardData>();
    public GameObject[] essenceBalls = new GameObject[10];

    public Sprite[] healthNumbers = new Sprite[10];
    public Sprite[] damageNumbers = new Sprite[10];
    public Sprite[] costNumbers = new Sprite[10];

    void Awake()
    {
        instance = this;

        playerADeck.Create();
        playerBDeck.Create();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void quiteGame() 
    {
        SceneManager.LoadScene(0);
    }

    public void endTurn() 
    {
    }
}
