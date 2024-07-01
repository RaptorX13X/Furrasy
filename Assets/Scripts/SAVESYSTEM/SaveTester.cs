using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TextCore.Text;

public class SaveTester : MonoBehaviour
{
    public SaveData saveData;
    public GameObject playerGameObject;
    public PointManager pointManager;
    public CharacterController controller;
    public Helf playerHealth;
    [SerializeField] private loadingSO loadingSo;

    [ContextMenu("Save")]
    private void Awake()
    {
        if (loadingSo.loading)
        {
            Load();
        }
    }

    public void Save()
    {
        Debug.Log("I'm saving");
        saveData.playerPoints = pointManager.score;
        saveData.playerPosition = playerGameObject.transform.position;
        saveData.playerRotation = playerGameObject.transform.rotation;
        saveData.playerHealth = playerHealth.currentHealth;
        saveData.sceneNumber = playerGameObject.GetComponent<PlayerMovement>().sceneNumber;
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
            Cursor.visible = true;
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }
}
