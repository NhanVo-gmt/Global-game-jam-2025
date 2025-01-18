using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] private PlayerStats playerStats;
    
    [Header("HealthUI")]
    [SerializeField] private List<Image> healthImages;
    [SerializeField] private Sprite activeHealth;
    [SerializeField] private Sprite inActiveHealth;

    private void Awake()
    {
        UpdateHealthUI(playerStats.currentHealth);
        playerStats.OnChangedHealth += UpdateHealthUI;
    }

    private void OnDestroy()
    {
        playerStats.OnChangedHealth -= UpdateHealthUI;
    }

    void UpdateHealthUI(int health)
    {
        for (int i = 0; i < health; i++)
        {
            healthImages[i].sprite = activeHealth;
        }
        
        for (int i = health; i < healthImages.Count; i++)
        {
            healthImages[i].sprite = inActiveHealth;
        }
    }
}
