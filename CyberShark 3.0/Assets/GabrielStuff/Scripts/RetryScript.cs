using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RetryScript : MonoBehaviour
{
    [SerializeField] private string newGameLevel = "LevelRestart";
    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameLevel);
    }
}
