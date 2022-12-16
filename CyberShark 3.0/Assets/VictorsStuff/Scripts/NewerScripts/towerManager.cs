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
    [SerializeField] ParticleSystem particles2;
    [SerializeField] ParticleSystem particles3;

    [SerializeField] float intervalMoment = 1.5f;
    [SerializeField] float momentM;

    [SerializeField] float initialMomentM;


    [SerializeField] bool played1;
    [SerializeField] bool played2;
    [SerializeField] bool played;




    private int towers;
    private int particles = 0;

    
    private float timer;
    [SerializeField] private float timeBetweenSwitches;

   



    // Start is called before the first frame update
    void Start()
    {
        timer = timeBetweenSwitches;

        momentM = timeBetweenSwitches - intervalMoment;
        initialMomentM = momentM;

    }

    // Update is called once per frame
    void Update()
    {
        ChangeActiveTower();
        TowerHandler();

        momentM = momentM - Time.deltaTime;

 

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

                if(momentM <= 0)
                {
                    
                    Debug.Log("tower2about to start");
                    particles2.Play();
                    momentM = momentM + timeBetweenSwitches;

                }
                

                break;
            case 1:
                tower1Collider.enabled = false;
                lamp1.SetActive(false);

                tower2Collider.enabled = true;
                lamp2.SetActive(true);

                tower3Collider.enabled = false;
                lamp3.SetActive(false);

                if (momentM <= 0)
                {
                    Debug.Log("tower3abouttostart");
                    particles3.Play();
                    momentM = momentM + timeBetweenSwitches;
                }



                break;
            case 2:
                tower1Collider.enabled = false;
                lamp1.SetActive(false);

                tower2Collider.enabled = false;
                lamp2.SetActive(false);

                tower3Collider.enabled = true;
                lamp3.SetActive(true);

                if (momentM <= 0)
                {
                    Debug.Log("tower1abouttostart");
                    particles1.Play();
                    momentM = momentM + timeBetweenSwitches;
                }




                break;
        }
            
    }
}
