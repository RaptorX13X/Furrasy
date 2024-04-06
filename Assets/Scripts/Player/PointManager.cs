using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointManager : MonoBehaviour
{
    private int score;

    public void AddPoint()
    {
        score += 1;
        Debug.Log(score);
    }
}
