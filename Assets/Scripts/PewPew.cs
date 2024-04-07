using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed;
    [SerializeField] private float despawnTime;
    private float lifetime;
    private bool hit;
    private Collider collider;
    [SerializeField] private GameObject hitParticlePrefab;

    private void Awake()
    {
        collider = GetComponent<Collider>();
    }

    private void Update()
    {
        if (hit) return;

        float movementSpeed = speed * Time.deltaTime;
        transform.Translate(Vector3.forward * movementSpeed);
        lifetime += Time.deltaTime;
        if (lifetime > despawnTime) Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        hit = true;
        Instantiate(hitParticlePrefab, transform.position, Quaternion.identity);
        collider.enabled = false;

        if (other.TryGetComponent(out Helf helf))
        {
            helf.TakeDamage();
        }
        Destroy(gameObject);
    }
}
