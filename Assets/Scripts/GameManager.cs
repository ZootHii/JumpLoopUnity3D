using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;



public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public GameObject menuUI;
    public GameObject rankUI;
    public GameObject canvasGameScore;
    public GameObject game;
    public GameObject startMenu;
    public GameObject userNamePanel;
    public GameObject resetUserNamePanel;
    public GameObject resetHighScorePanel;
    public Text userNameText;
    public Text[] userRank;
    public Text[] scoreRank;

    public int highest1Index;

    private bool gameOver = false;

    private void Awake()
    {
        instance = this;
    }

    public void GameOver()
    {
        gameOver = true;
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

    public void ShowRankPanel()
    {

        if (IsUserInfoSet())
        {
            rankUI.SetActive(true);
        }
        else
        {
            Debug.Log("isim gir"); // uyarı metni göster;
        }
    }

    public void CloseRankPanel()
    {
        rankUI.SetActive(false);
    }

    public void CloseUserNamePanel()
    {
        userNamePanel.SetActive(false);
    }

    public bool IsUserInfoSet()
    {

        if ((PlayerPrefs.GetString("UserName") == null) || (PlayerPrefs.GetString("UserName") == ""))
        {
            userNamePanel.SetActive(true);

            foreach (var user1 in FireBaseManager.instance.userList)
            {
                if (userNameText.text.ToString() == user1.username.ToString())
                {
                    return false;
                }
            }

        }
        else
        {
            userNamePanel.SetActive(false);
        }

        userNameText.text = PlayerPrefs.GetString("UserName");

        if ((userNameText.text.ToString() == ""))
        {
            return false;
        }
        else if ((userNameText.text.ToString() == null))
        {
            return false;
        }

        PlayerPrefs.SetString("UserName", userNameText.text.ToString());
        User user = new User(PlayerPrefs.GetString("UserName"), ScoreManager.instance.menuHighScoreInt); //her tıklamada high score reset
        FireBaseManager.instance.AddDatabase(user);
        userNamePanel.SetActive(false);
        return true;
    }

    public void SetLeaderBoard()
    {
        List<User> sortedList = FireBaseManager.instance.userList.OrderByDescending(o => o.score).ToList();

        if (sortedList.Count < 5)
        {
            for (int i = 0; i < sortedList.Count; i++)
            {
                userRank[i].text = sortedList[i].username;
                scoreRank[i].text = sortedList[i].score.ToString();
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                userRank[i].text = sortedList[i].username;
                scoreRank[i].text = sortedList[i].score.ToString();
            }
        }
    }

    public void ShowResetUserNamePanel()
    {

        resetUserNamePanel.SetActive(true);
    }

    public void ResetUserNamePanelButtonYes()
    {
        PlayerPrefs.DeleteKey("UserName");
        resetUserNamePanel.SetActive(false);
    }

    public void ResetUserNamePanelButtonNo()
    {
        resetUserNamePanel.SetActive(false);
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