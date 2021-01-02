using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private Text currentScoreText;
    [SerializeField]
    private Text highScoreText;
    private int currentScore = 0;
    private int highScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        currentScoreText.text = "0";
        if (PlayerPrefs.HasKey("HighScore"))
        {
            setHighScore(PlayerPrefs.GetInt("HighScore"));

        }
        else
        {
            setHighScore(0);
        }
    }

    public void increaseCurrentScore()
    {
        currentScoreText.text = (++currentScore).ToString();
        if (currentScore > highScore)
        {
            setHighScore(currentScore);
        }
    }

    public void setHighScore(int score)
    {
        highScoreText.text = score.ToString();
        highScore = score;
    }

    public void saveHighScore()
    {
        PlayerPrefs.SetInt("HighScore", highScore);
    }

    public void resetHighScore()
    {
        setHighScore(0);
        saveHighScore();
    }

    private void OnDestroy()
    {
        if (currentScore >= highScore)
        {
            saveHighScore();
        }
    }
}
