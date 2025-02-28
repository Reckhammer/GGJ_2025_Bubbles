using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Todo: make this into abstract class and implement children with int, float, etc. health values
public class Health : MonoBehaviour
{
    [Header("Health")]
    public int maxHealth = 2;
    public int currentHealth;
    public bool isDead = false;
    public HealthBar uiHealthBar;

    public event Action HealthChanged;
    public event Action MaxHealthChanged;
    public event Action Death;

    private void Start()
    {
        InitHealth();
    }

    protected virtual void InitHealth()
    {
        currentHealth = maxHealth;

        if (uiHealthBar != null)
        {
            uiHealthBar.SetMaxHealth(maxHealth);
            uiHealthBar.SetHealth(currentHealth);
        }
    }

    public virtual void ChangeHealth(int change)
    {
        currentHealth += change;
        Debug.Log($"{this.name} health changed from {currentHealth + (-1 * change)} to {currentHealth}");

        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }

        if (currentHealth <= 0)
        {
            Debug.Log($"{this.name} has died");
            currentHealth = 0;
            isDead = true;
            Death?.Invoke();
        }

        if (uiHealthBar != null)
            uiHealthBar.SetHealth(currentHealth);

        HealthChanged?.Invoke();
    }

    public virtual void DamageHealth(int damageAmt)
    {
        ChangeHealth(-1 * damageAmt);
    }

    public virtual void ChangeMaxHealth(int newMax)
    {
        MaxHealthChanged?.Invoke();

        maxHealth = newMax;

        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        else if (currentHealth < maxHealth)
            currentHealth += maxHealth - currentHealth;

        if (uiHealthBar != null)
        {
            uiHealthBar.SetMaxHealth(maxHealth);
            uiHealthBar.SetHealth(currentHealth);
        }
    }
}
