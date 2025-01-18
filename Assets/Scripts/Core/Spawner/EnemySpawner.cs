using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]

    public class Wave{
        public string waveName; 
        public List<EnemyGroup> enemyGroups; 
        public int waveQuota; // Number of enemy in this wave
        public float spawnInterval; // Time between each spawn of enemy
        public int spawnCount; // Number of enemy already spawned in this wave
    }

    [System.Serializable]

    public class EnemyGroup{
        public GameObject enemyPrefab;
        public string enemyName;
        public int enemyCount; // Number of enemy in this stage
        public int spawnCount; // Number of enemy already spawned
    }

    public List<Wave> waves; //List of all the waves
    public int currentWaveCount; // Index of current wave

    [Header("Spawner Attributes")]
    float spawnTimer; // Timer to decide when to spawn next enemy
    Transform player;
    public float waveInterval; //Interval between waves
    public int enemiesAlive;
    public int maxEnemiesAllowed; //Max numbeer of enemies allowed at once
    public bool maxEnemiesReached = false;

    [Header("Spawn Position")]
    public List<Transform> relativeSpawnPoints;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        CalculateWaveQuota();
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        if (currentWaveCount < waves.Count){
            StartCoroutine(NextWave());
        }
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= waves[currentWaveCount].spawnInterval){
            spawnTimer = 0;
            SpawnEnemies();
        }
    }

    void CalculateWaveQuota(){
        int currentWaveQuota = 0;
        foreach (var enemyGroup in waves[currentWaveCount].enemyGroups){
            currentWaveQuota += enemyGroup.enemyCount;
        }
        waves[currentWaveCount].waveQuota = currentWaveQuota;

        Debug.LogWarning(currentWaveQuota);
    }

    IEnumerator NextWave(){
        yield return new WaitForSeconds(waveInterval);
        if(currentWaveCount < waves.Count - 1){
            currentWaveCount++;
            CalculateWaveQuota();
        }
    }

    void SpawnEnemies(){
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached){
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups){
                if (enemyGroup.spawnCount < enemyGroup.enemyCount){
                    //Limit number spawned
                    if(enemiesAlive >= maxEnemiesAllowed){
                        maxEnemiesReached = true;
                        return;
                    }

                    //Spawn enemy at random spawn point
                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);
                    
                    enemyGroup.spawnCount++;
                    waves[currentWaveCount].spawnCount++;
                }
            }
        }
        // Reset if enemies count go down
        if (enemiesAlive < maxEnemiesAllowed){
            maxEnemiesReached = false;
        }
    }

    //Called when an enemy is killed
    public void onEnemyKilled(){
        enemiesAlive--;
    }
}
