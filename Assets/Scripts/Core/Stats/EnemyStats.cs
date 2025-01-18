using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    public EnemyDeath            enemyDeath;

    protected TypingObject typingObject;
    private   float        currentHealth;
    float                  currentMoveSpeed;
    float                  currentDamage;


    void Awake()
    {
        currentHealth    = enemyData.MaxHealth;
        currentMoveSpeed = enemyData.MoveSpeed;
        currentDamage    = enemyData.Damage;
        
        typingObject              =  GetComponent<TypingObject>();
        typingObject.OnFinishWord += OnFinishWord;
    }
    
    private void OnFinishWord()
    {
        TakeDamage(1f);
    }


    public void TakeDamage(float damage){
        currentHealth -= damage;
        if (currentHealth <= 0){
            Die();
        }
    }

    public void Die()
    {
        enemyDeath.OnDead();
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

