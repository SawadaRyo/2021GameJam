using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] Text[] scoreText;

    int score = 0;
    public void AddScore()
    {
        score++;
        if(scoreText[0] && scoreText[1])
        {
            scoreText[0].text = score.ToString("D3");
            scoreText[1].text = score.ToString("D3");
        }
    }
}
