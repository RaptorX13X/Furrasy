using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RendererOff : MonoBehaviour
{
    private MeshRenderer renderer;

    private void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        renderer.enabled = false;
    }
}
