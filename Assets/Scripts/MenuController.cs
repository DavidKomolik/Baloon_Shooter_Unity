using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    private void Start()
    {
        PlayerPrefs.SetInt("Difficulty", (int)Difficulty.EASY);
    }
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void SetDifficulty(int value)
    {
        Debug.Log("Difficulty set to: " + (Difficulty)value);
        PlayerPrefs.SetInt("Difficulty", value);
    }
}
