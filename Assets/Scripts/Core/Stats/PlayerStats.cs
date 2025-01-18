using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DataManager.MasterData;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundation.Scripts.Utilities.Extension;
using GameFoundationBridge;
using UnityEngine.UI;
using UserData.Model;
using Zenject;
public class PlayerStats : MonoBehaviour
{

    public PlayerScriptableObject playerData;
    public PlayerSound playerSound;

    [Inject] private GameSceneDirector gs;
    private          PlayerAnimation   anim;

    //current stats
    float      currentMoveSpeed;
    float      currentMight;
    float      currentDashSpeed;
    float      currentDashCooldown;
    float      currentDashDuration;
    public int currentHealth { get; private set; }

    public Action<int> OnChangedHealth;

    //I-Frame
    [Header("I-Frame")]
    public float iFrameDuration;
    float invincibleTime = 0;
    bool isInvincible = false;
    void Awake()
    {
        this.GetCurrentContainer().Inject(this);

        anim = GetComponent<PlayerAnimation>();
        
        currentMoveSpeed = playerData.MoveSpeed;
        currentHealth = playerData.MaxHealth;
        currentMight = playerData.Might;
        currentDashSpeed = playerData.DashSpeed;
        currentDashCooldown = playerData.DashCooldown;
        currentDashDuration = playerData.DashDuration;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibleTime > 0){
            invincibleTime -= Time.deltaTime;
        }
        else if (isInvincible){
            isInvincible = false;
        }
    }
    public void TakeDamage(int damage)
    {
        if (currentHealth < 0) return;
        
        // Debug.LogWarning("Player has taken damage");
        if (!isInvincible)
        {
            currentHealth -= damage;
            invincibleTime = iFrameDuration;
            isInvincible = true;
            
            OnChangedHealth?.Invoke(currentHealth);
            
            if (currentHealth <= 0)
            {
                playerSound.PlayDie();
                Die();
                anim.Die();
            }
            else
            {
                playerSound.PlayHit();
                anim.Hit(iFrameDuration);
            }
        }
    }

    public void Die()
    {
        StartCoroutine(DieCoroutine());
    }

    IEnumerator DieCoroutine()
    {
        yield return new WaitForSeconds(2f);
        
        gs.LoadGameOverScene();
    }
}