using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    [SerializeField] private AudioSource source;
    [SerializeField] private AudioClip runClip;
    [SerializeField] private AudioClip dashClip;

    public void PlayDash()
    {
        source.PlayOneShot(dashClip);
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
}
