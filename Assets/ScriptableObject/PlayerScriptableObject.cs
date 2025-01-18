using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerScriptableObject", menuName = "ScriptableObjects/Player")]
public class PlayerScriptableObject : ScriptableObject
{
    [SerializeField]
    float maxHealth;
    public float MaxHealth { get => maxHealth; private set => maxHealth = value; }

    [SerializeField]
    float moveSpeed;
    public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }

    [SerializeField]
    float might;
    public float Might { get => might; private set => might = value; }
    
    [SerializeField]
    float dashSpeed;
    public float DashSpeed { get => dashSpeed; private set => dashSpeed = value; }

    [SerializeField]

    float dashCooldown;
    public float DashCooldown { get => dashCooldown; private set => dashCooldown = value; }

    [SerializeField]
    float dashDuration;
    public float DashDuration { get => dashDuration; private set => dashDuration = value; }

}
