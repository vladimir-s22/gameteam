using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public static PlayerSwitcher instance;

    [SerializeField] Player _activePlayer;
    [SerializeField] Player _inActivePlayer;
    public int _turnNumber = 1;

    private void Awake()
    {
        if (instance != null && instance != this)
        { Destroy(this); }
        else
        { instance = this; }
    }

    public void SwitchPlayers()
    {
        // Debug.Log("[PlayerSwitcher::SwitchPlayers] Active player has " + _activePlayer.GetEssence() + " essence");
        // Debug.Log("[PlayerSwitcher::SwitchPlayers] Inactive player is " + _inActivePlayer.GetEssence() + " essence");
        Player tempPlayer;
        tempPlayer = _activePlayer;

        _activePlayer.IncrementEssence();
        _activePlayer = _inActivePlayer;
        _inActivePlayer = tempPlayer;
        _turnNumber++;
        EssenceController.instance.UpdateEssence();
    }

    public Player GetActivePlayer()
    {
        // Debug.Log("[PlayerSwitcher::GetActivePlayer] Active player is " + _activePlayer);
        return _activePlayer;
    }

    public Player GetInActivePlayer()
    {
        // Debug.Log("[PlayerSwitcher::GetInActivePlayer] Inactive player is " + _inActivePlayer);
        return _inActivePlayer;
    }
}
