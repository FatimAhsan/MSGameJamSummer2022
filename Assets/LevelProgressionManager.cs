using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressionManager : MonoBehaviour
{
    public static LevelProgressionManager instance;
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        scoreText.text = "LEVEL: "+ score.ToString() ;
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public int GetScore()
    {
        return score;
    }
    public void AddPoint()
    {
        score++;
        scoreText.text = "LEVEL:" + score.ToString();
    }
}
