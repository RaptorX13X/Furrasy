using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinZone : MonoBehaviour
{
    [SerializeField] private GameObject winScreen;
    [SerializeField] private GameObject inGameUI;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            inGameUI.SetActive(false);
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 0f;
        }
    }
}
