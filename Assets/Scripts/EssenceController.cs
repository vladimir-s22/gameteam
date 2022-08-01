using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EssenceController : MonoBehaviour
{
    public static EssenceController instance;

    [SerializeField] public List<GameObject> EssenceCrystals;

    private void Awake()
    {
        if (instance != null && instance != this)
        { Destroy(this); }
        else
        { instance = this; }
    }

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

        // Debug.Log("[EssenceController::UpdateEssence] Essence updated. Active player is " + PlayerSwitcher.instance.GetActivePlayer() + " and his essence is " + PlayerSwitcher.instance.GetActivePlayer().GetEssence());
    }
}
