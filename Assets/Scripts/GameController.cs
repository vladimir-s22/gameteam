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

    public Player activePlayer = null;

    public GameObject canvas = null;

    public int turnNumber = 1;

    public List<CardData> cards = new List<CardData>();
    public GameObject[] essenceBalls = new GameObject[10];

    public Sprite[] healthNumbers = new Sprite[10];
    public Sprite[] damageNumbers = new Sprite[10];
    public Sprite[] costNumbers = new Sprite[10];

    public GameObject cardPrefab = null;

    void Awake()
    {
        instance = this;

        activePlayer = playerA;
        
        playerA.essence = GameController.instance.turnNumber;
        playerB.essence = GameController.instance.turnNumber;

        playerA.hand = playerAHand;
        playerB.hand = playerBHand;

        Debug.Log("[Controller::Awake] Active player is " + activePlayer);
        Debug.Log("[Controller::Awake] Active player essence is " + activePlayer.essence);
        Debug.Log("[Controller::Awake] Turn number is " + turnNumber);
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
        if (activePlayer == playerA)
        {
            Debug.Log("[Controller::EndTurn::IfActivePlayer] Before switching active player is" + activePlayer);
            activePlayer = playerB;
            Debug.Log("[Controller::EndTurn::IfActivePlayer] Active player is" + activePlayer);

            activePlayer.essence = turnNumber;
            updateEssence();
        } else
        {
            Debug.Log("[Controller::EndTurn::IfActivePlayer] Before switching active player is" + activePlayer);
            turnNumber++;
            activePlayer = playerA;
            Debug.Log("[Controller::EndTurn::IfActivePlayer] Active player is" + activePlayer);
            activePlayer.essence = turnNumber;
            updateEssence();
        }
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
            if (activePlayer.essence > m)
            {
                essenceBalls[m].SetActive(true);
            } else
            {
                essenceBalls[m].SetActive(false);
            }
        }

        Debug.Log("[UpdateEssence] Essence updated. Active player is " + activePlayer + " and his essence is " + activePlayer.essence);
    }
}
