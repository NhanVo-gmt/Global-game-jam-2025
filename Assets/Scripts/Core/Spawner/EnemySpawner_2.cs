using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner_2 : MonoBehaviour
{
    [System.Serializable]
    public class Wave{
        public string waveName; 
        public List<EnemyGroup> enemyGroups; 
        public float waveQuota; // Max time until switch wave
        public float spawnInterval; // Time between each spawn of enemy
    }

    [System.Serializable]
    public class EnemyGroup{
        public GameObject enemyPrefab;
        public string enemyName;
        public float enemyRate; // Apparance rate of this enemy in this wave
    }

    public List<Wave> waves; //List of all the waves
    public int currentWaveCount; // Index of current wave
    public float Timer = 0.0f; // Playing time from start to finish

    [Header("Spawner Attributes")]
    float spawnTimer; // Timer to decide when to spawn next enemy
    Transform player;
    public float waveInterval; //Interval between waves
    public int enemiesAlive;
    public int maxEnemiesAllowed; //Max numbeer of enemies allowed at once
    public bool maxEnemiesReached = false;
    float spawn ;

    [Header("Spawn Position")]
    public List<Transform> relativeSpawnPoints;

    [Header("Sound")]
    public AudioSource source;

    public AudioClip bubbleClip;
    
    public static Action OnKillEnemy;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (currentWaveCount < waves.Count && Timer >= waves[currentWaveCount].waveQuota){
            StartCoroutine(NextWave());
        }
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= waves[currentWaveCount].spawnInterval){
            spawnTimer = 0;
            SpawnEnemies();
        }
}


    IEnumerator NextWave(){
        yield return new WaitForSeconds(waveInterval);
        if(currentWaveCount < waves.Count - 1){
            currentWaveCount++;
            Timer = 0.0f;
        }
    }

    void SpawnEnemies(){
        //Limit number spawned
        if(enemiesAlive >= maxEnemiesAllowed){
            maxEnemiesReached = true;
            return;
        }
        // Reset if enemies count go down
        if (enemiesAlive < maxEnemiesAllowed){
            maxEnemiesReached = false;
        }
        if ((Timer < waves[currentWaveCount].waveQuota || !(currentWaveCount < waves.Count-1)) && !maxEnemiesReached){
            spawn = Random.Range(0.0f, 1.0f);
            foreach (var enemyGroup in waves[currentWaveCount].enemyGroups){
                if (spawn <= enemyGroup.enemyRate){
                    //Spawn enemy at random spawn point
                    Instantiate(enemyGroup.enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);
                    enemiesAlive++;
                    return;
                }
                spawn = spawn - enemyGroup.enemyRate ;
            }
            // Instantiate(waves[currentWaveCount].enemyGroups[0].enemyPrefab, player.position + relativeSpawnPoints[Random.Range(0, relativeSpawnPoints.Count)].position, Quaternion.identity);
            // enemiesAlive++;
            // return;
        }
    }

    //Called when an enemy is killed
    public void onEnemyKilled(){
        enemiesAlive--;
        
        source.volume = Random.Range(0.8f, 1f);
        source.PlayOneShot(bubbleClip);
        
        OnKillEnemy?.Invoke();
    }
}
