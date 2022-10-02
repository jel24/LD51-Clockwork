using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Minion : MonoBehaviour
{

    [SerializeField] protected int startingPower = 0;
    [SerializeField] protected int startingHealth = 0;
    [SerializeField] protected int bonusHealth;
    [SerializeField] TextMeshPro healthText;
    [SerializeField] TextMeshPro powerText;
    [SerializeField] ParticleSystem deathFX;

    int bonusPower = 0;
    int power = 0;
    int health = 0;

    void Start()
    {
        power = startingPower + bonusPower;
        health = startingHealth + bonusPower * bonusHealth;
        powerText.text = power.ToString();
        healthText.text = health.ToString();
    }

    public virtual void Activate()
    {
        power++;
        health += 1;
        powerText.text = power.ToString();
        healthText.text = health.ToString();

    }

    public virtual void OnPlayEffect(int powerInHand)
    {
        bonusPower = powerInHand;
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
    }

    public void Heal(int howMuch)
    {
        health += howMuch;
        healthText.text = health.ToString();
    }

    public void Die()
    {
        Invoke("CleanUp", 1f);
        deathFX.Play();
    }

    void CleanUp()
    {
        Destroy(gameObject);
    }

    public int GetPower()
    {
        return power;
    }
}
