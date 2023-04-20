using Newtonsoft.Json.Bson;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HealthScript : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int score = 50;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioPlayer;
    ScoreKeeper scoreKeeper;

    LevelManager levelManager;

    void Awake()
    { 
        audioPlayer = FindObjectOfType<AudioPlayer>();
        cameraShake = Camera.main.GetComponent<CameraShake>();  
        scoreKeeper = FindObjectOfType<ScoreKeeper>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        DamageDealer damageDealer = other.GetComponent<DamageDealer>();

        if(damageDealer != null)
        {
            TakeDamage(damageDealer.getDamage());
            PlayHitEffect();
            audioPlayer.PlayHitClip();
            ShakeCamera();
            damageDealer.Hit();
        }
    }

    public int GetHealth()
    {
        return health;
    }

    void TakeDamage(int damage)
    {
        
        health -= damage;
        if(health <= 0)
        {
            Die();
           
        }
    }

    void Die()
    {
        if(!isPlayer)
        {
            scoreKeeper.AddScore(score);
        }
        else
        {
            levelManager.LoadGameOver();
        }
        Destroy(gameObject);
    }


    void PlayHitEffect()
    {
        if(hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }

    void ShakeCamera()
    {
        if(cameraShake != null && applyCameraShake)
        {
            cameraShake.Play();
        }
    }

    
}
