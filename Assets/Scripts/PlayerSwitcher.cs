using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public static PlayerSwitcher instance;

    [SerializeField] Player _activePlayer;
    [SerializeField] Player _inActivePlayer;
    private int _initialEssence = 1;
    public int TurnNumber = 1;

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
        Player tempPlayer = _activePlayer;
        _activePlayer.ReplenishEssence(_initialEssence);
        _activePlayer.IncrementEssence();
        _activePlayer.GetHand().AllowDragCards(false);
        _activePlayer.GetBoard().deactivateCards();

        // Here player is switched
        _activePlayer = _inActivePlayer;

        _activePlayer.Deck.dealCard(_activePlayer.GetHand().gameObject);
        _activePlayer.GetBoard().activateCards();
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
}
