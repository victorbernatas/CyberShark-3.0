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
    public GameObject uiEffect2;
    public GameObject playerDeathEffect;
    public float duration = 2f;
    private bool particlePlayed = true;
    private bool particlePlayedPart2 = true;


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
        if (particlePlayed)
        {
            Debug.Log("hehehe");
            Instantiate(uiEffect, startCollider.transform.position, Quaternion.identity);

            particlePlayed = false;

            yield return new WaitForSeconds(duration);
        }
        if (particlePlayedPart2)
        {
            Instantiate(uiEffect2, startCollider.transform.position, Quaternion.identity);

            particlePlayedPart2 = false;

            yield return new WaitForSeconds(duration);

            Destroy(startCollider);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        }

    IEnumerator PlayAgain()
        {
            if (particlePlayed)
        {
            Debug.Log("restarting");
            Instantiate(playerDeathEffect, sharkHead.transform.position, Quaternion.identity);

            particlePlayed = false;

            yield return new WaitForSeconds(duration);

            Destroy(sharkHead);

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        }
        
        }

    IEnumerator QuitGame()
        {
            if (particlePlayed)
        {
            Debug.Log("Quitting...");
            Instantiate(uiEffect, quitCollider.transform.position, Quaternion.identity);

            particlePlayed = false;

            yield return new WaitForSeconds(duration);

            Destroy(quitCollider);

            Application.Quit();
        }
        }

    
}
