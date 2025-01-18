using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using TMPro;
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

    [Header("PointUI")]
    [SerializeField] private TextMeshProUGUI pointText;

    private void Awake()
    {
        
    }

    private void Start()
    {
        UpdatePointUI(GameManager.Point);
        UpdateHealthUI(playerStats.currentHealth);

        GameManager.Instance.OnAddedPoint += UpdatePointUI;
        playerStats.OnChangedHealth       += UpdateHealthUI;
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

    void UpdatePointUI(int point, int addedPoint = 0)
    {
        pointText.text = point.ToString();
    }
}
