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
        instance = this;
        EssenceController.instance.UpdateEssence();

        PlayerSwitcher.instance.GetActivePlayer().Deck.Create("roman");
        PlayerSwitcher.instance.GetInActivePlayer().Deck.Create("eldritch");

        dealInitialHands();
        PlayerSwitcher.instance.GetInActivePlayer().GetHand().AllowDragCards(false);
        PlayerSwitcher.instance.GetActivePlayer().GetHand().AllowDragCards(true);
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    internal void dealInitialHands()
    {
        for (int i = 0; i < 5; i++)
        {
            PlayerSwitcher.instance.GetActivePlayer().Deck.dealCard(PlayerSwitcher.instance.GetActivePlayer().GetHand().gameObject);
        }

        for (int i = 0; i < 4; i++)
        {
            PlayerSwitcher.instance.GetInActivePlayer().Deck.dealCard(PlayerSwitcher.instance.GetInActivePlayer().GetHand().gameObject);
        }
    }
}
