using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void StartButton()
    {
        SceneManager.LoadScene(1);
    }

    public void HowToButton()
    {
        Debug.Log("to be implemented");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
