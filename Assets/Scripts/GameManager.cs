using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //public float delay = 1f;
    public GameObject menuUI;


    public void GameOver(){
        Debug.Log("Over");
        //Invoke("ShowMenu", delay);
        ShowMenu();
    }

    private void ShowMenu(){
        menuUI.SetActive(true);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
