using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helf : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        if (gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject);
        }

        if (gameObject.CompareTag("Player"))
        {
            //player death
        }
    }
}