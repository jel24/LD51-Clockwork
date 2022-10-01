using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HealthManager")]

public class HealthManager : ScriptableObject
{

    int currentHealth;
    public TriggeredEvent onDeath, updateHealth;
    public int startingHealth;

    void Awake()
    {
        currentHealth = startingHealth;
        updateHealth.Trigger();
    }


    public void TakeDamage(int howMuch)
    {
        currentHealth -= howMuch;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            onDeath.Trigger();
        }
        updateHealth.Trigger();
    }

    public int GetHealth()
    {
        return currentHealth;
    }
}
