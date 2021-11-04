using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour
{
    [SerializeField] Text scoreText;

    int score = 0;
    public void AddScore()
    {
        score++;
        if(scoreText)
        {
            scoreText.text = score.ToString("D3");
        }
    }
}
