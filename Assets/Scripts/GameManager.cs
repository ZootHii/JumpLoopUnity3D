using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public float delay = 1f;
    public static GameManager instance;
    public GameObject menuUI;
    private bool gameOver = false;

    private void Awake()
    {
        instance = this;
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
    }

}
