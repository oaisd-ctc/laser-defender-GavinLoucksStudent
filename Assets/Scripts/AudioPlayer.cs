using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f, 1f)] float shootingVolume = 1f;

    [Header("Damage")]
    [SerializeField] AudioClip hitClip;
    [SerializeField] [Range(0f,1f)] float hitVolume = 1f;
    
   

    public void PlayShootingClip()
    {
        if(shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayHitClip()
    {
        if(hitClip != null)
        {
            AudioSource.PlayClipAtPoint(hitClip, Camera.main.transform.position, hitVolume);
        }
    }
}
