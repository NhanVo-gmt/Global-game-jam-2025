using System;
using Unity.Mathematics;
using UnityEngine;

public class SquidDeath : EnemyDeath
{
    [Header("Damage")]
    public GameObject inkPrefab;
    
    protected override void Die()
    {
        base.Die();

        SpawnInk();
    }
    
    private void SpawnInk()
    {
        Instantiate(inkPrefab, transform.position, quaternion.identity);
    }
}