using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.TryGetComponent(out Helf helf);
            helf.Die();
        }

        if (other.CompareTag("Player"))
        {
            other.TryGetComponent(out RespawnController respawn);
            respawn.Respawn();
        }
    }
}
