using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cysharp.Threading.Tasks;
using DataManager.MasterData;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.Presenter;
using GameFoundation.Scripts.UIModule.ScreenFlow.BaseScreen.View;
using GameFoundationBridge;
using UnityEngine.UI;
using UserData.Model;
using Zenject;
public class PlayerStats : MonoBehaviour
{

    public PlayerScriptableObject playerData;

    private GameScreenView gs;

    //current stats
    float currentMoveSpeed;
    float currentHealth;
    float currentMight;
    float currentDashSpeed;
    float currentDashCooldown;
    float currentDashDuration;

    //I-Frame
    [Header("I-Frame")]
    public float iFrameDuration;
    float invincibleTime = 0;
    bool isInvincible = false;
    void Awake()
    {
        currentMoveSpeed = playerData.MoveSpeed;
        currentHealth = playerData.MaxHealth;
        currentMight = playerData.Might;
        currentDashSpeed = playerData.DashSpeed;
        currentDashCooldown = playerData.DashCooldown;
        currentDashDuration = playerData.DashDuration;
        gs = FindObjectOfType<GameScreenView>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
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
    public void TakeDamage(float damage){
        Debug.LogWarning("Player has taken damage");
        if (!isInvincible){
        currentHealth -= damage;
        invincibleTime = iFrameDuration;
        isInvincible = true;
        if (currentHealth <= 0){
            Die();
        }
        }
    }

    public void Die(){
        // gs.LoadGameOverScene();
    }

}