using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text scoreText;
    public Text highscoreText;

    int score = 0;
    int highscore = 0;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = score.ToString() + " POINTS";
        highscoreText.text = "HIGHSCORE: " + highscore.ToString();
    }

    public void AddPoint1()
    {
        score += 50;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
    public void AddPoint2()
    {
        score += 100;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
    public void AddPoint3()
    {
        score += 150;
        scoreText.text = score.ToString() + " POINTS";
        if (highscore < score)
            PlayerPrefs.SetInt("highscore", score);
    }
}
