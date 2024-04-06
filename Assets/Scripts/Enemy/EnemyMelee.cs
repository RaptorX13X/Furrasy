using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMelee : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float cooldown;
    private Transform target;
    private float remainingCooldown;
    [SerializeField] private float range;
    
    

    private void Awake()
    {
        remainingCooldown = 0f;
    }

    private void Update()
    {
        if (remainingCooldown > 0f)
        {
            remainingCooldown -= Time.deltaTime;
        }
        if (target == null) return;
        Debug.Log("target set");
        Vector3 lookPos = target.position - transform.position;
        lookPos.y = 0f;
        transform.rotation = Quaternion.LookRotation(lookPos);
        agent.SetDestination(target.position);
        if (remainingCooldown <= 0.01f)
        {
            Attack();
            remainingCooldown = cooldown;
        }
    }

    private void Attack()
    {
        if (Vector3.Distance(target.position, transform.position) <= range)
        {
            target.TryGetComponent(out Helf helf);
            helf.TakeDamage();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerMovement player))
        {
            target = player.transform;
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
