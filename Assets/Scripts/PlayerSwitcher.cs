using UnityEngine;

public class PlayerSwitcher : MonoBehaviour
{
    public static PlayerSwitcher instance;

    [SerializeField] public Player _activePlayer;
    [SerializeField] public Player _inActivePlayer;
    public int _turnNumber = 1;

    private void Start()
    {
        _activePlayer = new Player();
        _inActivePlayer = new Player();
    }

    public void SwitchPlayers()
    {
        // Debug.Log("[PlayerSwitcher::SwitchPlayers] Current active player is " + _activePlayer);
        // Debug.Log("[PlayerSwitcher::SwitchPlayers] Current inactive player is " + _inActivePlayer);
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
