using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] GameObject[] enemyPrefabs;
    [SerializeField] float timeBetweenSpawn = 1.5f;
    [SerializeField] Vector2 forceRange;

    private Camera mainCamera;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main; 
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime;
        
        if (timer <= 0)
        {
            SpawnEnemies();
            timer += timeBetweenSpawn;
        }

    }

    void SpawnEnemies()
    {
       Vector2 spawnPoint = Vector2.zero;
       Vector2 direction = Vector2.zero;
       int side = 4;

        switch (side)
        {
            case 0:
                // Left
                spawnPoint.x = 0;
                spawnPoint.y = Random.value;
                direction = new Vector2(1f, Random.Range(-1f, 1f));
                break;
            case 1:
                // Right
                spawnPoint.x = 1;
                spawnPoint.y = Random.value;
                direction = new Vector2(-1f, Random.Range(-1f, 1f));
                break;
            case 2:
                // Bottom
                spawnPoint.x = Random.value;
                spawnPoint.y = 0;
                direction = new Vector2(Random.Range(-1f, 1f), 1f);
                break;
            case 3:
                // Top
                spawnPoint.x = Random.value;
                spawnPoint.y = 1;
                direction = new Vector2(Random.Range(-1f, 1f), -1f);
                break;
        }




        Vector3 worldSpawnPoint = mainCamera.ViewportToWorldPoint(spawnPoint);
        worldSpawnPoint.z = 0;

        GameObject selectedAsteroid = enemyPrefabs[Random.Range(0, enemyPrefabs.Length)];

        GameObject asteroidInstance = Instantiate(selectedAsteroid, worldSpawnPoint,Quaternion.identity);

        Rigidbody rb = asteroidInstance.GetComponent<Rigidbody>();

        rb.velocity = direction.normalized * Random.Range(forceRange.x, forceRange.y);


    }



}
