using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public static PlayerSwitcher instance;

    [SerializeField] Player _activePlayer;
    [SerializeField] Player _inActivePlayer;
    private int _initialEssence = 1;
    public int TurnNumber = 1;

    public GameObject EndTurnButton;

    private void Awake()
    {
        if (instance != null && instance != this)
        { Destroy(this); }
        else
        { instance = this; }
        _activePlayer.Initialize();
        _activePlayer.GetHand().AllowDragCards(true);

        _inActivePlayer.Initialize();

        _activePlayer.GetGeneral().SetActiveEffect(true);
    }

    public void SwitchPlayers()
    {
        EndTurnButton.SetActive(true);

        Player tempPlayer = _activePlayer;
        _activePlayer.ReplenishEssence(_initialEssence);
        _activePlayer.IncrementEssence();
        _activePlayer.GetHand().AllowDragCards(false);
        _activePlayer.GetBoard().activateCards(false);

        if (GameController.instance.PlayedCard)
        {
            GameController.instance.PlayedCard = null;
        }

        // Here player is switched
        _activePlayer = _inActivePlayer;

        _activePlayer.GetHand().HideHand(false);
        foreach (Card card in _activePlayer.GetBoard().cards)
        {
            if (card.cardData.spellType == "draw")
            {
                for (int i = 0; i < card.cardData.spellPower; i++)
                {
                    _activePlayer.Deck.dealCard(_activePlayer.GetHand().gameObject);
                }
            }

            if (card.cardData.spellType == "rejuvenate")
            {
                _activePlayer.GetBoard().HealBoard(card.cardData.spellPower);
                _activePlayer.GetGeneral().getHeal(card.cardData.spellPower);
            }
        }


        _activePlayer.GetHand().CleanHand();
        _activePlayer.Deck.dealCard(_activePlayer.GetHand().gameObject);
        _activePlayer.GetBoard().activateCards(true);
        _initialEssence = _activePlayer.GetEssence();
        _inActivePlayer = tempPlayer;
        TurnNumber++;
        EssenceController.instance.UpdateEssence();
        _activePlayer.GetHand().AllowDragCards(true);
        updateGeneralsActiveEffect();
    }

    public Player GetActivePlayer()
    {
        return _activePlayer;
    }

    public Player GetInActivePlayer()
    {
        return _inActivePlayer;
    }

    private void updateGeneralsActiveEffect()
    {
        _activePlayer.GetGeneral().SetActiveEffect(true);
        _inActivePlayer.GetGeneral().SetActiveEffect(false);
    }

    public void HideActiveHand()
    {
        _activePlayer.GetHand().CleanHand();
        _activePlayer.GetHand().HideHand(true);
        EndTurnButton.SetActive(false);
    }
}
