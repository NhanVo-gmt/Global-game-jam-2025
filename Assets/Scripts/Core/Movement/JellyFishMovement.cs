using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JellyFishMovement : MonoBehaviour
{
    public float force;
    public float stopTime;
    
    private Transform      player;
    private Rigidbody2D    rb;
    private Coroutine      moveCoroutine;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb             = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>().transform;

        moveCoroutine = StartCoroutine(MoveCoroutine());
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
