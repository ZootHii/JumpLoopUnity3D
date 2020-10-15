using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject player;
    public GameObject menuUI;
    public GameObject rankUI;
    public GameObject canvasGameScore;
    public GameObject game;
    public GameObject startMenu;
    public GameObject userNamePanel;
    public GameObject resetUserNamePanel;
    public GameObject resetHighScorePanel;
    public Text userNameText;

    //private bool gameOver = false;

    private void Start()
    {
        PlayerPrefs.SetInt("UserIn", 0);
    }

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        //gameOver = true;
        ShowMenu();
    }

    private void ShowMenu()
    {
        ScoreManager.instance.ShowScoresOnMenu();
        menuUI.SetActive(true);

    }

    public void Play()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        startMenu.SetActive(false);

    }

    public void FirstPlay()
    {
        startMenu.SetActive(false);
        canvasGameScore.SetActive(true);
        game.SetActive(true);
    }
    
    public void SetScoreToLeaderBoard()
    {

        PlayGamesController.ShowLeaderBoardUI();

        /*if(PlayerPrefs.GetInt("UserIn") == 0)
        {
            // check user is in or not;
            if (PlayGamesController.AuthenticateUser())
            {
                PlayerPrefs.SetInt("UserIn", 1);
            }
            else
            {
                Debug.Log("giriş yapılamadı");
            }
        }

        if(PlayerPrefs.GetInt("UserIn") == 1)
        {
            //it user is in post score
            if (PlayGamesController.PostToLeaderBoard(PlayerPrefs.GetInt("HighScore")))
            {
                //if score is posted successful show leaderboard
                PlayGamesController.ShowLeaderBoardUI();
            }
            else
            {
                Debug.Log("score gitmedi");
            }
        }*/

    }

    public void ShowResetHighScorePanel()
    {
        resetHighScorePanel.SetActive(true);
    }

    public void ResetHighScorePanelButtonYes()
    {
        ScoreManager.instance.ResetHighScore();
        resetHighScorePanel.SetActive(false);
    }

    public void ResetHighScorePanelButtonNo()
    {
        resetHighScorePanel.SetActive(false);
    }
}