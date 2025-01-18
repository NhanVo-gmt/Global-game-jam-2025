using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public float lastTime = 2f;

    private void OnEnable()
    {
        Destroy(gameObject, lastTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<PlayerStats>(out PlayerStats stats))
        {
            stats.TakeDamage(1);
        }
    }
}
