using UnityEngine;

public class BattleCry : MonoBehaviour
{
    private Board _board;

    // Start is called before the first frame update
    void Start()
    {
        _board = GetComponent<Board>();
        _board.onCardPlay += castBattlecry;
    }

    private void castBattlecry(Card card)
    {
        Player activePlayer = PlayerSwitcher.instance.GetActivePlayer();
        Player inActivePlayer = PlayerSwitcher.instance.GetInActivePlayer();

        switch (card.cardData.battleCry)
        {
            case "increaseArmour":
                {
                    addArmour(1);
                    break;
                }
            case "drawCard":
                {
                    for (int i = 0; i < card.cardData.spellPower; i++)
                    {
                        activePlayer.Deck.dealCard(activePlayer.GetHand().gameObject);
                    }
                    break;
                }
            case "rejuvenate":
                {
                    activePlayer.GetBoard().HealBoard(card.cardData.spellPower);
                    activePlayer.GetGeneral().getHeal(card.cardData.spellPower);
                    break;
                }
            case "protector":
                {
                    activePlayer.GetBoard().Protect();
                    break;
                }
            default: break;
        }
    }

    private void addArmour(int amount)
    {
        foreach (Card iterateCard in _board.cards)
        {
            iterateCard.AddArmour(amount);
            iterateCard.UpdateCardVisual();
        }
    }
}
