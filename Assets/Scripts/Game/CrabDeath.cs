using System;
using GameFoundation.Scripts.Utilities.ObjectPool;
using UnityEngine;
using Zenject;

public class CrabDeath : EnemyDeath
{
    [Header("Damage")]
    public GameObject prefab;
    public float radius;
    
    protected override void Die()
    {
        base.Die();

        Instantiate(prefab, transform.position, Quaternion.identity);
        DamageArea();
    }

    void DamageArea()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var col in cols)
        {
            if (col.TryGetComponent<PlayerStats>(out PlayerStats stats))
            {
                stats.TakeDamage(1);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}