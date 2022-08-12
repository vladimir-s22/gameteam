using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class General : MonoBehaviour, IPointerDownHandler
{
    public Image HealthImage;
    public Image GeneralImage;

    public GameObject winScreen;
    public GameObject winBanner;

    public int _health = 30;
    public bool isProtected = false;

    public void getDamage(int damage)
    {
        if (_health > 0 && damage <= _health)
        {
            _health -= damage;
        } else
        {
            _health = 0;
        }

        HealthImage.sprite = FontContainer.instance.RedGlowNumbers[_health];

        if (_health == 0)
        {
            winBanner.SetActive(false);
            winScreen.SetActive(true);
        }
    }

    public void getHeal(int healPower)
    {
        _health += healPower;
        if (_health > 20)
        {
            _health = 20;
        }

        HealthImage.sprite = FontContainer.instance.RedGlowNumbers[_health];
    }

    public void SetActiveEffect(bool active)
    {
        gameObject.transform.Find("GeneralActive").gameObject.SetActive(active);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (GameController.instance.PlayedCard)
        {
            if (PlayerSwitcher.instance.GetActivePlayer().GetGeneral() != GetComponent<General>())
            {
                if (GameController.instance.PlayedCard.cardData.isSpell && GameController.instance.PlayedCard.cardData.spellType == "damage")
                {
                    getDamage(GameController.instance.PlayedCard.cardData.spellPower);
                    Destroy(GameController.instance.PlayedCard.gameObject);
                    GameController.instance.PlayedCard = null;
                } else
                {
                    if (!isProtected)
                    {
                        if (GameController.instance.PlayedCard.cardData.cardTitle == "Bombard Cannon")
                        {
                            getDamage(GameController.instance.PlayedCard.GetDamage() * 2);
                        } else
                        {
                            getDamage(GameController.instance.PlayedCard.GetDamage());
                        }

                        GameController.instance.PlayedCard.Activate(false);
                        GameController.instance.PlayedCard = null;
                    }
                }
            }
        }
    }
}
