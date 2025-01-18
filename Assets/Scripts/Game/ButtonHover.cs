using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;
using Ease = Watermelon.Ease;
using Image = UnityEngine.UI.Image;
using TweenExtensions = Watermelon.TweenExtensions;

public class ButtonHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Image  image;
    public Sprite normalSprite;
    public Sprite hoverSprite;

    private float    lerpDuration = 0.5f;
    private Sequence sequence;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        image.sprite = hoverSprite;
        
        sequence?.Kill();
        sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            TweenExtensions.DOScale(image.transform, 1.2f, lerpDuration).SetEasing(Ease.Type.BounceOut);
            TweenExtensions.DORotate(image.transform, new Vector3(0, 0, 10), lerpDuration)
                .SetEasing(Ease.Type.BounceOut);
        });
    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
        image.sprite = normalSprite;
        
        sequence?.Kill();
        sequence = DOTween.Sequence();
        sequence.AppendCallback(() =>
        {
            TweenExtensions.DOScale(image.transform, 1f, lerpDuration).SetEasing(Ease.Type.BounceOut);
            TweenExtensions.DORotate(image.transform, new Vector3(0, 0, 0), lerpDuration).SetEasing(Ease.Type.BounceOut); 
        });
    }
}
