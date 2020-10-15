using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayGamesController : MonoBehaviour
{

    private void Start()
    {
        InitializePlayGames();
    }

    public static void InitializePlayGames()
    {
        PlayGamesClientConfiguration config = new PlayGamesClientConfiguration.Builder().Build();
        PlayGamesPlatform.InitializeInstance(config);
        PlayGamesPlatform.Activate();
    }

    public static bool AuthenticateUser()
    {
        bool succesful = false;
        Social.localUser.Authenticate((bool success) =>
        {
            if (success)
            {
                succesful = true;
            }
            else
            {
                succesful = false;
            }
        });
        return succesful;
        /*PlayGamesPlatform.Instance.Authenticate(SignInInteractivity.CanPromptOnce, (result) => {
            
        });*/
    }


    public static bool PostToLeaderBoard(int score)
    {
        bool succesful = false;
        Social.ReportScore(score, GPGSIds.leaderboard_high_score, (bool result) =>
        {
                if (result)
                {
                    succesful = true;
                }
                else
                {
                    succesful = false;
                }
        });

        return succesful;
    }

    public static void ShowLeaderBoardUI()
    {
        PlayGamesPlatform.Instance.ShowLeaderboardUI(GPGSIds.leaderboard_high_score);
    }
}
