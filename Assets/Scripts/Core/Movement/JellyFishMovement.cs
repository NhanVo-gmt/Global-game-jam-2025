using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishMovement : EnemyMovement
{
    public float force;
    public float stopTime;
    
    private Rigidbody2D    rb;
    private Coroutine      moveCoroutine;

    protected override void Awake()
    {
        base.Awake();
        
        rb = GetComponent<Rigidbody2D>();
    }

    protected override void Start()
    {
        base.Start();

        moveCoroutine     =  StartCoroutine(MoveCoroutine());
        enemyDeath.OnDeadAction += () =>
        {
            StopCoroutine(moveCoroutine);
            moveCoroutine = null;
        };
    }

    IEnumerator MoveCoroutine()
    {
        float timeElapse = 0f;
        while (true)
        {
            timeElapse -= Time.deltaTime;

            if (timeElapse <= 0f)
            {
                timeElapse = stopTime;
                if (player.transform.position.x < transform.position.x)
                {
                    spriteRenderer.flipX = true;
                }
                else spriteRenderer.flipX = false;

                Vector2 direction = (player.transform.position - transform.position).normalized;
                rb.AddForce(direction * force, ForceMode2D.Impulse);
            }

            yield return null;
        }
    }
}
