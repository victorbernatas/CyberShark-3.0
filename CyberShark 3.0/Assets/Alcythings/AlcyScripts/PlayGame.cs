using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    [SerializeField] GameObject startMenu;
    [SerializeField] GameObject player;
    [SerializeField] GameObject quitMenu;
    [SerializeField] GameObject startCollider;
    [SerializeField] GameObject quitCollider;
    [SerializeField] GameObject sharkHead;
    public GameObject uiEffect;
    public GameObject playerDeathEffect;
    public float duration = 2f;


    private void Update()
    {
        
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;

            if (startMenu == null && startMenu.Equals(null) && sceneName == "Newnewstart")
            {
               StartCoroutine(StartGame());
            }
        

        
        if (player == null && player.Equals(null) && sceneName == "Level" )
        {
           StartCoroutine(PlayAgain());
            
        }

        if (quitMenu == null && quitMenu.Equals(null) && sceneName == "Newnewstart")
        {
          StartCoroutine(QuitGame());
        }
    }


    IEnumerator StartGame()
        {
        Debug.Log("hehehe");
        Instantiate(uiEffect, startCollider.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

    IEnumerator PlayAgain()
        {
        Debug.Log("restarting");
        Instantiate(playerDeathEffect, sharkHead.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(duration);

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }

    IEnumerator QuitGame()
        {
        Debug.Log("Quitting...");
        Instantiate(uiEffect, quitCollider.transform.position, Quaternion.identity);

        yield return new WaitForSeconds(duration);

        Application.Quit();
        }

    
}
