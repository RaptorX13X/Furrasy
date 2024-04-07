using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject gunPoint;
    [SerializeField] private AudioClip shootSound;
    private float remainingCooldown;

    private void Awake()
    {
        remainingCooldown = 0f;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && remainingCooldown <= 0.01f)
        {
            Instantiate(laserPrefab, gunPoint.transform.position, gunPoint.transform.rotation);
            SoundManager.instance.PlaySound(shootSound);
            remainingCooldown = cooldown;
        }

        if (remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
    }
}
