using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointManager pointManager))
        {
            pointManager.AddPoint();
            Destroy(this.gameObject);
        }
    }
}
