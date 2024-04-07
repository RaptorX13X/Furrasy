using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorIsLava : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        other.TryGetComponent(out Helf helf);
        helf.Die();
    }
}
