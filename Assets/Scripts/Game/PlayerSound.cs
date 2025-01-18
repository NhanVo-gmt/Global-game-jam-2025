using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioSource oneShotSource;
    [SerializeField] private AudioClip runClip;
    [SerializeField] private AudioClip dashClip;
    [SerializeField] private AudioClip buttonClip;
    [SerializeField] private AudioClip hitClip;
    [SerializeField] private AudioClip dieClip;

    public void PlayDash()
    {
        oneShotSource.PlayOneShot(dashClip, Random.Range(0.8f, 1f));
    }

    public void PlayRun()
    {
        if (source.isPlaying && source.clip == runClip) return;
        
        source.clip = runClip;
        source.Play();
    }

    public void StopRun()
    {
        if (source.clip != runClip) return;
        
        source.Stop();
    }

    public void PlayHit()
    {
        oneShotSource.PlayOneShot(hitClip, Random.Range(0.8f, 1f));
    }
    
    public void PlayDie()
    {
        oneShotSource.PlayOneShot(dieClip, Random.Range(0.8f, 1f));
    }

    private void Update()
    {
        if (Input.anyKeyDown && !String.IsNullOrWhiteSpace(Input.inputString))
        {
            oneShotSource.volume = Random.Range(0.8f, 1f);
            oneShotSource.PlayOneShot(buttonClip);
        }
    }
}
