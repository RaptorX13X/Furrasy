using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject tootCanvas;
    [SerializeField] private GameObject menuCanvas;

    private void Start()
    {
        menuCanvas.SetActive(true);
        tootCanvas.SetActive(false);
    }

    public void StartButton()
    {
        SceneManager.LoadScene(1);
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

    public void ExitButton()
    {
        Application.Quit();
    }
}
