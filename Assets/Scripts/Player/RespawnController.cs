using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnController : MonoBehaviour
{
    [SerializeField] private Helf playerHelf;
    [SerializeField] private Transform respawnPoint;
    [SerializeField] private CharacterController controller;

    public void Respawn()
    {
        playerHelf.TakeDamage();
        controller.enabled = false;
        transform.position = respawnPoint.position;
        controller.enabled = true;
    }
}
