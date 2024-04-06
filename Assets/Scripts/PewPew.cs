using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PewPew : MonoBehaviour
{
    [Header("Stats")]
    [SerializeField] private float speed;
    [SerializeField] private int damage;
    [SerializeField] private float despawnTime;
    private float lifetime;
    private bool hit;
    private Collider collider;

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
        collider.enabled = false;

        if (other.TryGetComponent(out Helf helf))
        {
            helf.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
