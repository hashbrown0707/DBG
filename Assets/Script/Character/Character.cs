using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public PlayerData data;

    public int maxHealth { get; private set; }
    public int health { get; private set; }
    public int block { get; private set; }


    public event Action OnCharacterHealthChanged;
    public event Action OnCharacterBlockChanged;

    #region Health, Block And Damage
    public void TakeDamage(int damage)
    {
        int blockResult = damage - block;

        if(blockResult < 0)
            SetBlock(Math.Abs(blockResult));
        else
        {
            int healthResult = health - blockResult;
            SetBlock(0);
            SetHealth(healthResult);
        }

        if (health <= 0)
            Die();
    }

    private void Die()
    {

    }

    public void SetHealth(int health)
    {
        this.health = health;
        OnCharacterHealthChanged?.Invoke();
    }

    public void SetMaxHealth(int maxHealth)
    {
        health += (maxHealth - this.maxHealth);
        this.maxHealth = maxHealth;
        OnCharacterHealthChanged?.Invoke();
    }

    public void SetBlock(int value)
    {
        block = value;
        OnCharacterBlockChanged?.Invoke();
    }

    #endregion

    #region Unity Call Back Function
    private void Start()
    {

        ResetCharacter();
    }


    #endregion

    private void ResetCharacter()
    {
        SetMaxHealth(data.maxHealth);
        SetHealth(maxHealth);
        SetBlock(0);

    }
}
