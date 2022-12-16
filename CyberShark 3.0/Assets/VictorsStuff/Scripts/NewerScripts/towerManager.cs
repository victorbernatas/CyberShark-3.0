using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class towerManager : MonoBehaviour
{
    [SerializeField] Collider tower1Collider;
    [SerializeField] Collider tower2Collider;
    [SerializeField] Collider tower3Collider;

    [SerializeField] GameObject lamp1;
    [SerializeField] GameObject lamp2;
    [SerializeField] GameObject lamp3;

    [SerializeField] ParticleSystem particles1;


    private bool tower1Activated;
    private bool tower2Activated;
    private bool tower3Activated;

    private int towers;
    private int particles = 0;

    
    private float timer;
    [SerializeField] private float timeBetweenSwitches;

    private float particleTimer;
    float timeBetweenParticles;
    [SerializeField] float particleWindow = 1.5f;

    //[SerializeField] float 




    // Start is called before the first frame update
    void Start()
    {
        timer = timeBetweenSwitches;
        timeBetweenParticles = timeBetweenSwitches - particleWindow;
        particleTimer = timeBetweenParticles;
        
    }

    // Update is called once per frame
    void Update()
    {
        ChangeActiveTower();
        TowerHandler();
        //PlayParticles();

        
    }

    private void ChangeActiveTower()
    {


        timer = timer - Time.deltaTime;

        if (timer <= 0)
        {
            towers = towers +1;
            
            if(towers == 3)
            {
                towers = 0;
            }

            timer = timer + timeBetweenSwitches;
            
        }
    }

    private void PlayParticles()
    {
        particleTimer = particleTimer - Time.deltaTime;
        if (particleTimer <= 0)
        {
            particles = particles + 1;

            if(particles ==3)
            {
                particles = 0;
            }

            particleTimer = particleTimer + timeBetweenParticles;
        }


        switch (particles)
        {
            case 0:
                particles1.Stop();
                particles1.Play();
                
                break;
            case 1:
                particles1.Stop();
                particles1.Play();
                break;
            case 2:
                particles1.Stop();
                particles1.Play();
                break;
        }
    }

    private void TowerHandler()
    {
        

        switch (towers)
        {
            case 0:
                tower1Collider.enabled = true;
                lamp1.SetActive(true);

                tower2Collider.enabled = false;
                lamp2.SetActive(false);

                tower3Collider.enabled = false;
                lamp3.SetActive(false);

                

                break;
            case 1:
                tower1Collider.enabled = false;
                lamp1.SetActive(false);

                tower2Collider.enabled = true;
                lamp2.SetActive(true);

                tower3Collider.enabled = false;
                lamp3.SetActive(false);


               
                break;
            case 2:
                tower1Collider.enabled = false;
                lamp1.SetActive(false);

                tower2Collider.enabled = false;
                lamp2.SetActive(false);

                tower3Collider.enabled = true;
                lamp3.SetActive(true);

                

               
                break;
        }
            



       if (tower1Activated)
        {
            tower1Collider.enabled = true;
            lamp1.SetActive(true);

            tower2Collider.enabled = false;
            lamp2.SetActive(false);

            tower3Collider.enabled = false;
            lamp3.SetActive(false);
        }

       if(tower2Activated)
        {
            tower1Collider.enabled = false;
            lamp1.SetActive(false);

            tower2Collider.enabled = true;
            lamp2.SetActive(true);

            tower3Collider.enabled = false;
            lamp3.SetActive(false);
        }

        if (tower2Activated)
        {
            tower1Collider.enabled = false;
            lamp1.SetActive(false);

            tower2Collider.enabled = false;
            lamp2.SetActive(false);

            tower3Collider.enabled = true;
            lamp3.SetActive(true);
        }
    }
}
