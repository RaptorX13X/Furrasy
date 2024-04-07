using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helf : MonoBehaviour
{
    [SerializeField] private int maxHealth;
    [SerializeField] private AudioClip playerDamagedSound;
    private int currentHealth;
    public event Action<Helf> OnDestroyed;

    private void OnDestroy()
    {
        OnDestroyed?.Invoke(this);
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage()
    {
        currentHealth -= 1;
        Debug.Log(currentHealth);
        if (currentHealth > 0 && gameObject.CompareTag("Player"))
        {
            SoundManager.instance.PlaySound(playerDamagedSound);
        }
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
