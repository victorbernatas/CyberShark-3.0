using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SharkManager : MonoBehaviour
{
    [SerializeField] int killCount;
    [SerializeField] int score;

    [SerializeField] int hp = 1;

    [SerializeField] int killCountForMiddlePart;
    [SerializeField] int killCountForBackPart;

    [SerializeField] GameObject middlePart;
    [SerializeField] GameObject backPart;

    [SerializeField]private bool middlePartActivated;
    [SerializeField] private bool backPartActivated;

    public TMP_Text scoreText;

    public const string HighScoreKey = "HighScore";


    void Start()
    {
        middlePart.SetActive(false);
        backPart.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        AddMiddlePart();
        AddBackPart();
        
    }


    public void AddKill()
    {
        if (!backPartActivated)
        {
            killCount = killCount + 1;
            Debug.Log(killCount);
        }
 
    }

    public void AddScore(int scoreValue)
    {
        if (scoreText != null)
        {
            if (!middlePartActivated && !backPartActivated)
            {
                score = score + scoreValue;
            }

            if (middlePartActivated && !backPartActivated)
            {
                score = score + scoreValue * 2;
            }

            if (middlePartActivated && backPartActivated)
            {
                score = score + scoreValue * 4;
            }
            score = score + scoreValue;
            scoreText.text = score.ToString();
        }
        


    }

    


    void AddMiddlePart()
    {
        if (killCount >= killCountForMiddlePart && !middlePartActivated)
        {
            middlePart.SetActive(true);
            killCount = 0;
          
            middlePartActivated = true;
            hp = hp + 1;

        }
    }

    void AddBackPart()
    {
        if (killCount >= killCountForBackPart && !backPartActivated)
        {
            backPart.SetActive(true);
            killCount = 0;
          
            backPartActivated = true;
            hp = hp + 1;
        }
    }


    public void CollisionHandler()
    {
        if(backPartActivated)
        {
            backPart.SetActive(false);
            hp = hp - 1;
            killCount = 0;
            backPartActivated = false;
            Debug.Log("Backpartgone"+ killCount);
            return;
        }
        if (!backPartActivated && middlePartActivated)
        {
            middlePart.SetActive(false);
            hp = hp - 1;
            killCount = 0;
            middlePartActivated = false;
            Debug.Log("Middlepartgone" + killCount);
            return;
        }
        if (!backPartActivated && !middlePartActivated)
        {
            hp = hp - 1;
            killCount = 0;
            Debug.Log("You basically died" + killCount);
            Death();

        }
    }

    void Death()
    {
        if (hp == 0)
        {
            Destroy(gameObject);
        }
    }


    private void OnDestroy()
    {
        int currentHighScore = PlayerPrefs.GetInt(HighScoreKey, 0);
        if (score > currentHighScore)
        {
            PlayerPrefs.SetInt(HighScoreKey, score);
        }
    }
}
