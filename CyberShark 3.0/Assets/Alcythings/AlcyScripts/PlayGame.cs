using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject player;
    [SerializeField] GameObject quitmenu;



    private void Update()
    {
        
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (startMenu == null && sceneName == "NewStart")
            {
                StartGame();
            }
        

        
        if (player == null && sceneName == "Level" )
        {
            PlayAgain();
            
        }

        if (quitmenu == null && sceneName == "NewStart")
        {
            QuitGame();
        }
    }


    public void StartGame()
        {
        Debug.Log("hehehe");
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
