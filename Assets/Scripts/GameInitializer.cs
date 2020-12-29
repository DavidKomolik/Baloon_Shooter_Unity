using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    public GameObject CurrentAmmoText;
    public GameObject AmmoDivider;
    public GameObject TotalAmmoText;

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
            }
            else
            {
                CurrentAmmoText.SetActive(false);
                AmmoDivider.SetActive(false);
                TotalAmmoText.SetActive(false);
            }
        }
    }
}
