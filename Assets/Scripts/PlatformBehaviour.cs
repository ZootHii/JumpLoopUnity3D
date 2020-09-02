using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformBehaviour : MonoBehaviour
{
    public static PlatformBehaviour instance;

    public float scaleX = 2.0f;
    public float scaleZ = 2.0f;

    private void Awake()
    {
        instance = this;
    }

    private void FixedUpdate()
    {
        transform.localScale = new Vector3(scaleX, transform.localScale.y, scaleZ);
    }

    public void IncreaseScale()
    {
        if (ScoreManager.instance.gameScoreInt == 10 || ScoreManager.instance.gameScoreInt == 20)
        {
            scaleX += 0.7f;
            scaleZ += 0.7f;
        }
        else if (ScoreManager.instance.gameScoreInt == 30)
        {
            scaleX += 1.0f;
            scaleZ += 1.0f;
        }
    }
}
