using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] protected Transform visual;
    [SerializeField] protected float     flySpeed;
    [SerializeField] protected float     rotateSpeed;
    [SerializeField] protected float     deathDuration;
    
    protected Animator     animator;
    protected EnemySpawner es;

    public bool   isDead { get; private set; } = false;
    public Action OnDeadAction;

    protected const string DIE_ANIM = "Die";

    protected virtual void Awake()
    {
        animator = GetComponentInChildren<Animator>();

        isDead = false;
    }

    private void Start()
    {
        es = FindObjectOfType<EnemySpawner>();
    }
    
    void OnDestroy() {
        es.onEnemyKilled();
    }

    public void OnDead()
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
        
        Destroy(gameObject);
    }

    protected virtual void Die()
    {
        isDead = true;
        animator.Play(DIE_ANIM);
        OnDeadAction?.Invoke();
    }
}
