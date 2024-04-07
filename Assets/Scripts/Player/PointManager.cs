using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    public int score;
    [SerializeField] private TextMeshProUGUI pointText;

    private void Awake()
    {
        score = 0;
        pointText.text = score.ToString();
    }

    public void AddPoint()
    {
        score += 1;
        pointText.text = score.ToString();
    }
}
