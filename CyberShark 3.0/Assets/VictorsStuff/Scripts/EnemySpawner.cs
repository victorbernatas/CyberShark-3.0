using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawn = 1.5f;
    [SerializeField] Vector2 spawnPoint;
    //[SerializeField] Vector2 forceRange;

    private Camera mainCamera;
    private float timer;


    [SerializeField] Transform[] spawnPoints;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        timer = timer- Time.deltaTime;
        
        if (timer <= 0)
        {
            SpawnEnemies();
            
            timer = timer+ timeBetweenSpawn;
            
        }

    }

    void SpawnEnemies()
    {
        Vector3 spawnPos = spawnPoints[Random.Range(0, spawnPoints.Length)].transform.position;
        Vector3 realSpawnPos = new Vector3(spawnPos.x, 0.85f, spawnPos.z);
        Quaternion spawnRotation = Quaternion.Euler(0, 90, 0);


        Instantiate(enemyPrefab,realSpawnPos, spawnRotation);
        
    }
    


    }




