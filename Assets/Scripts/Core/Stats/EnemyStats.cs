using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    float currentHealth;
    float currentMoveSpeed;
    float currentDamage;    

    EnemySpawner es;


    void Awake()
    {
        currentHealth    = enemyData.MaxHealth;
        currentMoveSpeed = enemyData.MoveSpeed;
        currentDamage    = enemyData.Damage;
    }

    private void Start()
    {
        es = FindObjectOfType<EnemySpawner>();
    }

    public void TakeDamage(float damage){
        currentHealth -= damage;
        if (currentHealth <= 0){
            Die();
        }
    }

    public void Die(){
        Destroy(gameObject);
    }

    void OnDestroy(){
        es.onEnemyKilled();
    }

    void OnTriggerStay2D(Collider2D col)
    {    
            if (col.gameObject.CompareTag("Player"))
        {
            Debug.Log("Enemy hit player");
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentDamage);
        }
    }
}

