using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject crabPrefab;
    [SerializeField] GameObject piranhaPrefab;
    [SerializeField] GameObject octopusPrefab;

    [SerializeField] float timeBetweenCrabSpawn = 1.5f;
    

    [SerializeField] float timeBeforePiranha;
    [SerializeField] float piranhaSpawnInterval;
    [SerializeField] float piranhaTimer;
    //[SerializeField] Vector2 forceRange;


    [SerializeField] float timeBeforeOctopus;
    [SerializeField] float octopusSpawnInterval;
    [SerializeField] float octopusTimer;


    private float timer;


    [SerializeField] Transform[] spawnPoints;


    
    void Start()
    {
        piranhaTimer = piranhaSpawnInterval;
        octopusTimer = octopusSpawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer- Time.deltaTime;
        
        if (timer <= 0)
        {
            SpawnCrabs();
            
            timer = timer+ timeBetweenCrabSpawn;
            
        }


        timeBeforePiranha = timeBeforePiranha - Time.deltaTime;

        if(timeBeforePiranha <= 0)
        {
            SpawnPiranhas();
            

           
        }

        timeBeforeOctopus = timeBeforeOctopus - Time.deltaTime;
        if(timeBeforeOctopus <=0)
        {
            SpawnOctopus();
        }

    }

    void SpawnCrabs()
    {

        
        Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        Vector3 realSpawnPos = new Vector3(spawnPos.x, 0.85f, spawnPos.z);
      


        Instantiate(crabPrefab,realSpawnPos, Quaternion.identity);
        
    }

    void SpawnPiranhas()
    {
        piranhaTimer = piranhaTimer - Time.deltaTime;

        if (piranhaTimer <= 0)
        {
            
           
            Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            Vector3 realSpawnPos = new Vector3(spawnPos.x, 0.85f, spawnPos.z);
           

            Instantiate(piranhaPrefab, realSpawnPos, Quaternion.identity);

            piranhaTimer = piranhaSpawnInterval;
        }
        
    }


    void SpawnOctopus()
    {
        octopusTimer = octopusTimer - Time.deltaTime;

        if (octopusTimer <= 0)
        {

            
            Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
            Vector3 realSpawnPos = new Vector3(spawnPos.x, 0.85f, spawnPos.z);


            Instantiate(octopusPrefab, realSpawnPos, Quaternion.identity);

            octopusTimer = octopusSpawnInterval;
        }

    }



}




