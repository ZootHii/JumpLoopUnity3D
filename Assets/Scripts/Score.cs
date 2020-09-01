using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public int scoreInt;

    private void Update()
    {
        scoreText.text = scoreInt.ToString();
    }

}
