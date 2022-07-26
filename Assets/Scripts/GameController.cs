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

    public Player playerA = null;
    public Player playerB = null;

    public GameObject canvas = null;

    public List<CardData> cards = new List<CardData>();
    public GameObject[] essenceBalls = new GameObject[10];

    public Sprite[] healthNumbers = new Sprite[10];
    public Sprite[] damageNumbers = new Sprite[10];
    public Sprite[] costNumbers = new Sprite[10];

    public GameObject cardPrefab = null;

    void Awake()
    {
        instance = this;

        playerA.isActive = true;
        playerA.hand = playerAHand;
        playerA.essence = 1;

        playerB.isActive = false;
        playerB.hand = playerBHand;
        playerB.essence = 1;
    }
    // Start is called before the first frame update
    void Start()
    {
        playerADeck.Create();
        playerBDeck.Create();
        updateEssence();
        dealHands();
    }

    public void quitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void endTurn()
    {
    }

    internal void dealHands()
    {
        for (int i = 0; i < 5; i++)
        {
            playerADeck.dealCard(playerA.hand);
            playerBDeck.dealCard(playerB.hand);
        }
    }

    internal bool useCard(Card card, Player usingOnPlayer, Hand fromHand)
    {
        return true;
    }

    internal bool cardValid(Card card, Player usingOnPlayer, Hand fromHand)
    {
        bool valid = false;
        if (card == null)
            return false;

        if (fromHand.isActive)
            if (card.cardData.cost <= usingOnPlayer.essence)
            {

            }

        return valid;
    }

    internal void updateEssence()
    {
        for (int m = 0; m < 10; m++)
        {
            if (playerA.essence > m)
            {
                essenceBalls[m].SetActive(true);
            } else
            {
                essenceBalls[m].SetActive(false);
            }
        }
    }
}
