using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Echolocation : MonoBehaviour
{
    public List<MeshRenderer> renderers = new List<MeshRenderer>();

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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            foreach (MeshRenderer renderer in renderers)
            {
                renderer.enabled = true;
            }
        }
    }
}
