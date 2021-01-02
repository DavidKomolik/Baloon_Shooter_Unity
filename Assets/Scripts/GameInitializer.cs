using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject CurrentAmmoText;
    public GameObject AmmoDivider;
    public GameObject TotalAmmoText;
    public HandgunScriptLPFP handgunScriptLPFP;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.HasKey("Difficulty"))
        {
            Difficulty difficulty = (Difficulty)PlayerPrefs.GetInt("Difficulty");
            if (difficulty == Difficulty.HARD)
            {
                CurrentAmmoText.SetActive(true);
                AmmoDivider.SetActive(true);
                TotalAmmoText.SetActive(true);
                handgunScriptLPFP.autoReload = false;
                handgunScriptLPFP.reloadEnabled = true;
            }
            else if(difficulty == Difficulty.EASY)
            {
                CurrentAmmoText.SetActive(false);
                AmmoDivider.SetActive(false);
                TotalAmmoText.SetActive(false);
                handgunScriptLPFP.reloadEnabled = false;
            }
            else
            {
                // Medium
                CurrentAmmoText.SetActive(true);
                AmmoDivider.SetActive(true);
                TotalAmmoText.SetActive(true);
                handgunScriptLPFP.autoReload = true;
                handgunScriptLPFP.reloadEnabled = true;
            }
        }
    }
}
