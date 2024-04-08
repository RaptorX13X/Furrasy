using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private Transform newRespawn;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (other.TryGetComponent(out RespawnController respawnController))
            {
                respawnController.SetRespawnAtCheckpoint(newRespawn);
            }
        }
    }
}
