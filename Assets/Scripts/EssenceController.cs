using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceController : MonoBehaviour
{
    public static EssenceController instance;

    [SerializeField] public List<GameObject> EssenceCrystals;

    public void UpdateEssence()
    {
        for (int m = 0; m < 10; m++)
        {
            if (PlayerSwitcher.instance.GetActivePlayer().GetEssence() > m)
            {
                EssenceCrystals[m].SetActive(true);
            } else
            {
                EssenceCrystals[m].SetActive(false);
            }
        }

        // Debug.Log("[EssenceController::updateEssence] Essence updated. Active player is " + activePlayer + " and his essence is " + activePlayer.essence);
    }

}
