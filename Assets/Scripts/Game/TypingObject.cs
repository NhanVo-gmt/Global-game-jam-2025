using System;
using System.Collections;
using System.Collections.Generic;
using Game;
using TMPro;
using UnityEngine;

public class TypingObject : MonoBehaviour
{
    [SerializeField] private string          startText;
    [SerializeField] private RectTransform   imageRect;
    [SerializeField] private TextMeshProUGUI typingUI;

    private const float  IMAGE_BASE_LENGTH = 2f;
    private string remainingText;
    private string typeText;

    public Action OnFinishWord;

    private void Start()
    {
        SetText(GameManager.Instance.GetRandomWord());
    }

    public void SetText(string text)
    {
        remainingText = text;
        typeText      = "";
        UpdateUI();
    }

    void UpdateUI()
    {
        if (remainingText.Length == 0)
        {
            typingUI.gameObject.SetActive(false);
            imageRect.gameObject.SetActive(false);
            return;
        }
        
        typingUI.text    = $"<color=red>{typeText}</color>{remainingText}";
        
        float textWidth = typingUI.preferredWidth;
        imageRect.sizeDelta = 
            new Vector2(IMAGE_BASE_LENGTH + textWidth, imageRect.sizeDelta.y);
        
        imageRect.gameObject.SetActive(true);
        typingUI.gameObject.SetActive(true);
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

            if (remainingText.Length == 0)
            {
                GameManager.Instance.AddPoint(1);
                OnFinishWord?.Invoke();
            }
        }
    }

    private bool IsCorrectLetter(string letter)
    {
        return remainingText.Length > 0 && remainingText.IndexOf(letter, StringComparison.OrdinalIgnoreCase) == 0;
    }

    private void RemoveLetter()
    {
        typeText      += remainingText[0];
        remainingText =  remainingText.Remove(0, 1);
        
        UpdateUI();
    }
}
