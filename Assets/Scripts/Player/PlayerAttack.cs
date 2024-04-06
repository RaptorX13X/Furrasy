using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject gunPoint;
    private float remainingCooldown;

    private void Awake()
    {
        remainingCooldown = 0;
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && remainingCooldown <= 0.01f)
        {
            Debug.Log("sram");
            Instantiate(laserPrefab, gunPoint.transform.position, Quaternion.identity);
            remainingCooldown = cooldown;
        }

        if (remainingCooldown != 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
    }
}
