using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private PointManager pointManager;

    private void Start()
    {
        scoreText.text = pointManager.score.ToString();
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene(0);
    }
}
