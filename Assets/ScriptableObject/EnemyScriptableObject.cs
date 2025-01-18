using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Blueprints;

[CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
public class EnemyScriptableObject : ScriptableObject
{
    //Base stat
    [SerializeField] float maxMoveSpeed;
    [SerializeField] float minMoveSpeed;
    public           float MoveSpeed { get => Random.Range(minMoveSpeed, maxMoveSpeed);  }
    
    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value;}

    [SerializeField]
    int damage;
    public int Damage{get => damage; private set => damage = value;}

    public TypingType type;
}
