using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRanged : MonoBehaviour
{
    [SerializeField] private GameObject gunPoint;
    [SerializeField] private GameObject bananaPrefab;
    [SerializeField] private float cooldown;
    private Transform target;
    private float remainingCooldown;

    private void Awake()
    {
        remainingCooldown = 0f;
    }

    private void Update()
    {
        if (remainingCooldown != 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
        if (target == null) return;
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0f;
        transform.rotation = Quaternion.LookRotation(lookPos);
        if (remainingCooldown <= 0.1f)
        {
            Debug.Log("shooting");
            Instantiate(bananaPrefab, gunPoint.transform.position, transform.rotation);
            remainingCooldown = cooldown;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            target = other.transform;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            target = null;
        }
    }
}
