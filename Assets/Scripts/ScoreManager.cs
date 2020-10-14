using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    
    public static ScoreManager instance;
    public Text gameScoreText;
    public Text menuScoreText;
    public Text menuHighScoreText;
    public int gameScoreInt;
    public int menuHighScoreInt;

    private void Awake()
    {
        instance = this;
        menuHighScoreInt = PlayerPrefs.GetInt("HighScore");
    }

    public void IncreaseScore()
    {
        gameScoreInt++;
        UpdateHighScore();
        gameScoreText.text = gameScoreInt.ToString();

    }

    public void UpdateHighScore()
    {
        //check high score
        if (gameScoreInt > menuHighScoreInt)
        {
            menuHighScoreInt = gameScoreInt;
        }

        PlayerPrefs.SetInt("HighScore", menuHighScoreInt);
    }

    public void ShowScoresOnMenu()
    {
        menuScoreText.text = gameScoreInt.ToString();
        menuHighScoreText.text = menuHighScoreInt.ToString();
    }

    public void ResetHighScore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        menuHighScoreInt = 0;
        menuHighScoreText.text = menuHighScoreInt.ToString();
    }
}
