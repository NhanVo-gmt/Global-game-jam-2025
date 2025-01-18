using System;
using System.Collections;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.Playables;
using Watermelon;

public class LoadingUI : MonoBehaviour
{
    [SerializeField] private PlayableDirector intro;
    [SerializeField] private PlayableDirector outro;

    public async UniTask PlayOutro()
    {
        outro.Play();
        
        await UniTask.Delay(TimeSpan.FromSeconds(outro.duration));
    }
    
    public void PlayIntro()
    {
        intro.Play();
    }
}
