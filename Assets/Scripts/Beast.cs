using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Beast : MonoBehaviour
{

    [SerializeField] protected int startingPower = 0;
    [SerializeField] protected int startingHealth = 0;
    [SerializeField] ParticleSystem attackAnimation;
    [SerializeField] ParticleSystem deathAnimation;
    [SerializeField] HealthManager healthManager;
    [SerializeField] TextMeshPro healthText;
    [SerializeField] TextMeshPro powerText;
    [SerializeField] AudioSource audioSource;
    [SerializeField] AudioClip[] clips;

    int power = 0;
    int health = 0;
    bool isDead = false;

    void Start()
    {
        powerText.text = startingPower.ToString();
        healthText.text = startingHealth.ToString();
        power = startingPower;
        health = startingHealth;
        audioSource.clip = clips[Random.Range(0, clips.Length)];
        audioSource.Play();
    }

    public virtual void Activate()
    {
        power++;
        powerText.text = power.ToString();
        healthText.text = health.ToString();

    }

    public virtual void Attack()
    {
        if (!isDead)
        {
            healthManager.TakeDamage(power);
            attackAnimation.Play();
            audioSource.clip = clips[Random.Range(0, clips.Length - 1)];
            audioSource.Play();
        }
    }

    public void TakeDamage(int howMuch)
    {
        health -= howMuch;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        healthText.text = health.ToString();
        audioSource.clip = clips[Random.Range(0, clips.Length - 1)];
        audioSource.Play();
    }

    public void Die()
    {
        bool isDead = true;
        deathAnimation.Play();
        Invoke("CleanUp", 1f);
    }

    void CleanUp()
    {
        Destroy(gameObject);
    }

    public void Clash(Minion m)
    {
        if (!isDead)
        {
            m.TakeDamage(power);
            attackAnimation.Play();
            TakeDamage(m.GetPower());
            healthText.text = health.ToString();
        }


    }

}
