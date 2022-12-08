using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighScoreScript : MonoBehaviour
{
    
    [SerializeField] private TMP_Text highScoreText;
    


    void Start()
    {
        int highScore = PlayerPrefs.GetInt(SharkManager.HighScoreKey, 0);
        highScoreText.text = $"HIGHSCORE : {highScore}";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
