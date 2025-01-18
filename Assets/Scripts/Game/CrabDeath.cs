using System;
using UnityEngine;

public class CrabDeath : EnemyDeath
{
    [Header("Damage")]
    public float radius;
    
    protected override void Die()
    {
        base.Die();
        
    }

    void DamageArea()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, radius);
        foreach (var col in cols)
        {
            if (col.TryGetComponent<PlayerMovement>(out PlayerMovement playerMovement))
            {
                //todo damage player
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}