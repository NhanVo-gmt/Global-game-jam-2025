using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [System.Serializable]

    public class Wave{
        public string waveName;
        public List<EnemyGroup> enemyGroups;
        public int waveQuota;
        public float spawnInterval;
        public int spawnCount;
    }

    [System.Serializable]

    public class EnemyGroup{
        public GameObject enemyPrefab;
        public string enemyName;
        public int enemyCount;
        public int spawnCount;
    }

    public List<Wave> waves;
    public int currentWaveCount;

    [Header("Spawner Attributes")]
    float spawnTimer;
    Transform player;
    public float waveInterval;
    public int enemiesAlive;
    public int maxEnemiesAllowed;
    public bool maxEnemiesReached = false;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        CalculateWaveQuota();
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
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

    void SpawnEnemies(){
        if (waves[currentWaveCount].spawnCount < waves[currentWaveCount].waveQuota && !maxEnemiesReached){
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups){
                if (enemyGroup.spawnCount < enemyGroup.enemyCount){
                    //Limit number spawned
                    if(enemiesAlive >= maxEnemiesAllowed){
                        maxEnemiesReached = true;
                        return;
                    }
                    //Spawn enemy on random pos near player
                    Vector2 spawnPosition = new Vector2(player.position.x + Random.Range(-10f, 10f), player.position.y + Random.Range(-10f, 10f));
                    Instantiate(enemyGroup.enemyPrefab, spawnPosition, Quaternion.identity);
                    
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
