using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        Vector3 lookPos = player.transform.position - transform.position;
        lookPos.y = 0f;
        transform.rotation = Quaternion.LookRotation(lookPos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PointManager pointManager))
        {
            pointManager.AddPoint();
            Destroy(this.gameObject);
        }
    }
}
