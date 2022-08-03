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
        _activePlayer.Initialize();
        _inActivePlayer.Initialize();

        _activePlayer.GetGeneral().SetActiveEffect(true);
    }

    public void SwitchPlayers()
    {
        Player tempPlayer;
        tempPlayer = _activePlayer;

        _activePlayer.IncrementEssence();
        _activePlayer = _inActivePlayer;
        _inActivePlayer = tempPlayer;
        _turnNumber++;
        EssenceController.instance.UpdateEssence();
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
