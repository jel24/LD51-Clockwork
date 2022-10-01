using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Beast : MonoBehaviour
{

    [SerializeField] protected int startingPower = 0;
    [SerializeField] protected int startingHealth = 0;

    [SerializeField] HealthManager healthManager;
    [SerializeField] TextMeshPro healthText;
    [SerializeField] TextMeshPro powerText;

    int power = 0;
    int health = 0;

    void Start()
    {
        powerText.text = startingPower.ToString();
        healthText.text = startingHealth.ToString();
        power = startingPower;
        health = startingHealth;
    }

    public virtual void Activate()
    {
        power++;
        powerText.text = power.ToString();
        healthManager.TakeDamage(power);
    }

    public void TakeDamage(int howMuch)
    {
        health -= howMuch;
        if (health <= 0)
        {
            health = 0;
            Die();
        }
        healthText.text = startingHealth.ToString();
    }

    public void Die()
    {
        Invoke("CleanUp", 1f);
    }

    void CleanUp()
    {
        Destroy(gameObject);
    }


}