using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPPickUp : MonoBehaviour
{
    private GameObject player;
    [SerializeField] private AudioClip hpSound;

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
        if (other.TryGetComponent(out Helf helf) && other.CompareTag("Player"))
        {
            helf.AddHealth();
            SoundManager.instance.PlaySound(hpSound);
            Destroy(this.gameObject);
        }
    }
}
