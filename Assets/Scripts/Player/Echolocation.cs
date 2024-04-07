using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Echolocation : MonoBehaviour
{
    public List<MeshRenderer> renderers = new List<MeshRenderer>();
    [SerializeField] private ParticleSystem particles;
    [SerializeField] private float cooldown;
    private float remainingCooldown;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out MeshRenderer renderer))
        {
            renderers.Add(renderer);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.TryGetComponent(out MeshRenderer renderer))
        {
            renderers.Remove(renderer);
        }
    }

    private void Start()
    {
        remainingCooldown = 0f;
    }


    private void Update()
    {
        if (remainingCooldown > 0)
        {
            remainingCooldown -= Time.deltaTime;
        }
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            particles.Play();
            remainingCooldown = cooldown;
            foreach (MeshRenderer renderer in renderers)
            {
                if (renderer == null)
                {
                    continue;
                }
                renderer.enabled = true;
            }
        }
    }
}
