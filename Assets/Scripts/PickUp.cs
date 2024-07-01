using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private AudioClip figSound;
    [SerializeField] private SaveData saveData;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        saveData = GameObject.FindGameObjectWithTag("SaveSystem").GetComponent<SaveData>();
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
            SoundManager.instance.PlaySound(figSound);
            Destroy(gameObject);
        }
    }
}
