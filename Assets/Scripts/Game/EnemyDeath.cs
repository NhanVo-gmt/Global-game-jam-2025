using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    [SerializeField] private Transform visual;
    [SerializeField] private float     flySpeed;
    [SerializeField] private float     rotateSpeed;
    [SerializeField] private float     deathDuration;
    
    private TypingObject typingObject;
    private Animator     animator;

    private const string DIE_ANIM = "Die";

    private void Awake()
    {
        animator                  =  GetComponentInChildren<Animator>();
        typingObject              =  GetComponent<TypingObject>();
        typingObject.OnFinishWord += OnFinishWord;
    }

    private void OnFinishWord()
    {
        StartCoroutine(DeathCoroutine());
    }

    IEnumerator DeathCoroutine()
    {
        animator.Play(DIE_ANIM);
        
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
}
