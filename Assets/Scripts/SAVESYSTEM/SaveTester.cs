using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class SaveTester : MonoBehaviour
{
    public SaveData saveData;
    public GameObject playerGameObject;
    public PointManager pointManager;
    public CharacterController controller;
    public Helf playerHealth;

    [ContextMenu("Save")]
    public void Save()
    {
        Debug.Log("I'm saving");
        saveData.playerPoints = pointManager.score;
        saveData.playerPosition = playerGameObject.transform.position;
        saveData.playerRotation = playerGameObject.transform.rotation;
        saveData.playerHealth = playerHealth.currentHealth;
        
        SerializationManager.Save("test", saveData);
    }

    [ContextMenu("Load")]
    public void Load()
    {
        Debug.Log("I'm loading");
        saveData = (SaveData)SerializationManager.Load("test");
        pointManager.score = saveData.playerPoints;
        pointManager.UpdateUI();
        playerHealth.currentHealth = saveData.playerHealth;
        playerHealth.UpdateUI();
        controller.enabled = false;
        playerGameObject.transform.position = saveData.playerPosition;
        playerGameObject.transform.rotation = saveData.playerRotation;
        controller.enabled = true;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Cursor.lockState = CursorLockMode.Confined;
        }
    }
}
