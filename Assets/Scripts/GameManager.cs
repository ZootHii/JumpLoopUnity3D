using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Linq;


public class GameManager : MonoBehaviour
{
    //public float delay = 1f;
    public static GameManager instance;
    public GameObject menuUI;
    public GameObject rankUI;
    public GameObject canvasGameScore;
    public GameObject game;
    public GameObject startMenu;
    public GameObject userNamePanel;
    public Text userNameText;
    public Text[] userRank;
    public Text[] scoreRank;

    public int highest1Index;

    private bool gameOver = false;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlayerPrefs.DeleteKey("UserName");
    }

    public void GameOver()
    {
        gameOver = true;
        //Invoke("ShowMenu", delay);
        ShowMenu();
    }

    private void ShowMenu()
    {
        ScoreManager.instance.ShowScoresOnMenu();
        menuUI.SetActive(true);
    }

    public void Play()
    {
        //System.Threading.Thread.Sleep(500);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        startMenu.SetActive(false);

    }

    public void FirstPlay()
    {
        startMenu.SetActive(false);
        canvasGameScore.SetActive(true);
        game.SetActive(true);
    }

    public void ShowRank()
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

    public void CloseRank()
    {
        rankUI.SetActive(false);
    }

    public bool IsUserInfoSet()
    {

        if ((PlayerPrefs.GetString("UserName") == null) || (PlayerPrefs.GetString("UserName") == ""))
        {
            userNamePanel.SetActive(true);
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

        
        foreach (var user1 in FireBaseManager.instance.userList)
        {
            if(userNameText.text.ToString() == user1.username.ToString()){
                return false;
            }
        }

        PlayerPrefs.SetString("UserName", userNameText.text.ToString());
        User user = new User(PlayerPrefs.GetString("UserName"), ScoreManager.instance.menuHighScoreInt); //her tıklamada high score reset
        FireBaseManager.instance.AddDatabase(user);
        userNamePanel.SetActive(false);
        //Debug.Log(PlayerPrefs.GetString("UserName"));
        return true;
    }

    public void SetLeaderBoard()
    {


        List<User> sortedList = FireBaseManager.instance.userList.OrderByDescending(o => o.score).ToList();


        foreach (var user in sortedList)
        {
            Debug.Log(user.username + " " + user.score);
        }

        for (int i = 0; i < 5; i++)
        {
            userRank[i].text = sortedList[i].username;
            scoreRank[i].text = sortedList[i].score.ToString();
        }

    }
}