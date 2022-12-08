using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject player;



    private void Update()
    {
        
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (startMenu == null && sceneName == "StartMenu")
            {
                StartGame();
            }
        

        
        if (player == null && sceneName == "Level" )
        {
            PlayAgain();
            
        }
    }


    public void StartGame()
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void PlayAgain()
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

        public void QuitGame()
        {
            Debug.Log("Quitting...");
            Application.Quit();
        }

    
}
