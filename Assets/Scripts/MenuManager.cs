using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject tootCanvas;
    [SerializeField] private GameObject menuCanvas;
    [SerializeField] private GameObject creditsCanvas;
    [SerializeField] private loadingSO loadingSo;

    
    public SaveData saveData;
    
    private void Start()
    {
        menuCanvas.SetActive(true);
        tootCanvas.SetActive(false);
        creditsCanvas.SetActive(false);
    }

    public void StartButton()
    {
        loadingSo.loading = false;
        SceneManager.LoadScene(1);
    }
    public void Lvl2()
    {
        loadingSo.loading = false;
        SceneManager.LoadScene(2);
    }

    public void LoadButton()
    {
        saveData = (SaveData)SerializationManager.Load("test");
        loadingSo.loading = true;
        SceneManager.LoadScene(saveData.sceneNumber);
    }

    public void HowToButton()
    {
        menuCanvas.SetActive(false);
        tootCanvas.SetActive(true);
    }

    public void ReturnFromToot()
    {
        menuCanvas.SetActive(true);
        tootCanvas.SetActive(false);
    }

    public void Credits()
    {
        menuCanvas.SetActive(false);
        creditsCanvas.SetActive(true);
    }
    
    public void CreditsLeave()
    {
        menuCanvas.SetActive(true);
        creditsCanvas.SetActive(false);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
