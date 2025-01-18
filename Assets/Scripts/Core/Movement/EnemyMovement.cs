using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    protected Transform      player;
    protected SpriteRenderer spriteRenderer;
    protected EnemyDeath     enemyDeath;

    
    protected virtual void Awake()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        enemyDeath     = GetComponent<EnemyDeath>();
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyDeath.isDead) return;
        
        Move();
    }

    void Move()
    {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime);

        if (player.transform.position.x < transform.position.x)
        {
            spriteRenderer.flipX = true;
        }
        else spriteRenderer.flipX = false;
    }
}
