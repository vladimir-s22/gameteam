using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    public GameObject canvas;
    public Card PlayedCard;

    void Awake()
    {
        EssenceController.instance.UpdateEssence();

        PlayerSwitcher.instance.GetActivePlayer().Deck.Create("roman");
        PlayerSwitcher.instance.GetInActivePlayer().Deck.Create("eldritch");

        dealInitialHands();
    }

    // Start is called before the first frame update
    // void Start()
    // {
        // playerADeck.Create();
        // playerBDeck.Create();

        // updateEssence();
        // dealHands();

        // playerAcardsInDeck.sprite = GameController.instance.healthNumbers[playerADeck.cardDatas.Count];
        // playerBcardsInDeck.sprite = GameController.instance.healthNumbers[playerBDeck.cardDatas.Count];

        // updateHands();
    // }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    // public void endTurn()
    // {
        // if (activePlayer == playerA)
        // {
        //     Debug.Log("[Controller::EndTurn::IfActivePlayer] Before switching active player is" + activePlayer);
        //     activePlayer = playerB;
        //     if (playerBDeck.cardDatas.Count > 0)
        //     {
        //         playerBDeck.dealCard(playerB.hand);
        //     }

        //     playerA.generalActiveEffect.SetActive(false);
        //     playerB.generalActiveEffect.SetActive(true);
        //     playerB.board.activateCards();
        //     playerA.board.deactivateCards();
        //     Debug.Log("[Controller::EndTurn::IfActivePlayer] Active player is" + activePlayer);

        //     activePlayer.essence = turnNumber;
        //     updateEssence();
        // } else
        // {
        //     Debug.Log("[Controller::EndTurn::IfActivePlayer] Before switching active player is" + activePlayer);
        //     turnNumber++;
        //     activePlayer = playerA;
        //     if (playerADeck.cardDatas.Count > 0)
        //     {
        //         playerADeck.dealCard(playerA.hand);
        //     }

        //     playerA.generalActiveEffect.SetActive(true);
        //     playerB.generalActiveEffect.SetActive(false);
        //     playerA.board.activateCards();
        //     playerB.board.deactivateCards();
        //     Debug.Log("[Controller::EndTurn::IfActivePlayer] Active player is" + activePlayer);
        //     activePlayer.essence = turnNumber;
        //     updateEssence();
        // }
        // updateHands();
        // playerAcardsInDeck.sprite = GameController.instance.healthNumbers[playerADeck.cardDatas.Count];
        // playerBcardsInDeck.sprite = GameController.instance.healthNumbers[playerBDeck.cardDatas.Count];
        // endTurnButton.SetActive(true);
    // }

    internal void dealInitialHands()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerSwitcher.instance.GetActivePlayer().Deck.dealCard(PlayerSwitcher.instance.GetActivePlayer().GetHand());
        }

        for (int i = 0; i < 4; i++)
        {
            PlayerSwitcher.instance.GetInActivePlayer().Deck.dealCard(PlayerSwitcher.instance.GetInActivePlayer().GetHand());
        }
    }

    // internal void updateHands()
    // {
        // if (activePlayer == playerA)
        // {
        //     playerA.hand.activateCards();
        //     playerB.hand.deactivateCards();
        // } else
        // {
        //     playerB.hand.activateCards();
        //     playerA.hand.deactivateCards();
        // }
    // }

    // public void hideActiveHand()
    // {
        // GameController.instance.activePlayer.hand.deactivateCards();
        // endTurnButton.SetActive(false);
    // }
}
