using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] protected Transform visual;
    [SerializeField] protected float     flySpeed;
    [SerializeField] protected float     rotateSpeed;
    [SerializeField] protected float     deathDuration;
    
    protected TypingObject typingObject;
    protected Animator     animator;

    public bool   isDead { get; private set; } = false;
    public Action OnDead;

    protected const string DIE_ANIM = "Die";

    protected virtual void Awake()
    {
        animator                  =  GetComponentInChildren<Animator>();
        typingObject              =  GetComponent<TypingObject>();
        typingObject.OnFinishWord += OnFinishWord;

        isDead = false;
    }

    private void OnFinishWord()
    {
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
        Die();
        
        float startTime = Time.deltaTime;
        while (startTime + deathDuration >= Time.deltaTime)
        {
            transform.Translate(Vector2.up * flySpeed * Time.deltaTime);
            
            // Rotate Visual
            float rotationAngle = rotateSpeed * Time.deltaTime;

            Quaternion rotation = Quaternion.Euler(0f, 0f, rotationAngle);

            visual.rotation *= rotation;

            yield return null;
        }
        
        gameObject.SetActive(false);
    }

    protected virtual void Die()
    {
        isDead = true;
        animator.Play(DIE_ANIM);
        OnDead?.Invoke();
    }
}
