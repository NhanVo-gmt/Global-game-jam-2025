using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TypingObject : MonoBehaviour
{
    [SerializeField] private string          startText;
    [SerializeField] private TextMeshProUGUI typingUI;

    private string remainingText;
    private string typeText;

    private void Start()
    {
        SetText(startText);
    }

    public void SetText(string text)
    {
        remainingText = text;
        typeText      = "";
        UpdateUI();
    }

    void UpdateUI()
    {
        typingUI.text = $"<color=red>{typeText}</color>{remainingText}";
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            string keyPressed = Input.inputString;
            
            if (keyPressed.Length == 1)
                EnterLetter(keyPressed);
        }
    }

    private void EnterLetter(string typedLetter)
    {
        if (IsCorrectLetter(typedLetter))
        {
            RemoveLetter();
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingText.Length > 0 && remainingText[0].ToString().ToLower().Equals(letter.ToLower());
    }

    private void RemoveLetter()
    {
        typeText      += remainingText[0];
        remainingText =  remainingText.Remove(0, 1);
        
        UpdateUI();
    }
}
