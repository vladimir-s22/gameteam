using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance { get; private set; }

    [SerializeField] GameObject canvas;
    [SerializeField] Card PlayedCard;

    void Awake()
    {
        if (instance != null && instance != this)
        { Destroy(this); }
        else
        { instance = this; }

        EssenceController.instance.UpdateEssence();
        Debug.Log(PlayerSwitcher.instance.GetActivePlayer().GetHand());
        // playerA.generalActiveEffect.SetActive(true);

        // playerA.essence = GameController.instance.turnNumber;
        // playerB.essence = GameController.instance.turnNumber;

        // playerA.hand = playerAHand;
        // Debug.Log("[Controller::Awake] Current playerA board is " + playerA.board.boardArea);

        // playerB.hand = playerBHand;
        // Debug.Log("[Controller::Awake] Current playerB board is " + playerB.board.boardArea);

        // Debug.Log("[Controller::Awake] Active player is " + activePlayer);
        // Debug.Log("[Controller::Awake] Active player essence is " + activePlayer.essence);
        // Debug.Log("[Controller::Awake] Turn number is " + turnNumber);
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

    // public void quitGame()
    // {
    //     SceneManager.LoadScene(0);
    // }

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

    // internal void dealHands()
    // {
        // for (int i = 0; i < 5; i++)
        // {
        //     playerADeck.dealCard(playerA.hand);
        // }

        // for (int i = 0; i < 4; i++)
        // {
        //     playerBDeck.dealCard(playerB.hand);
        // }
    // }

    // internal void updateEssence()
    // {
        // for (int m = 0; m < 10; m++)
        // {
        //     if (activePlayer.essence > m)
        //     {
        //         essenceBalls[m].SetActive(true);
        //     } else
        //     {
        //         essenceBalls[m].SetActive(false);
        //     }
        // }

        // Debug.Log("[GameController::updateEssence] Essence updated. Active player is " + activePlayer + " and his essence is " + activePlayer.essence);
    // }

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

    public Card GetPlayedCard()
    {
        return PlayedCard;
    }
}
