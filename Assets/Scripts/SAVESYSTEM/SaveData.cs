using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData 
{
    private static SaveData _current;

    public static SaveData Current => _current ??= new SaveData();
    
    public Vector3 playerPosition;
    public Quaternion playerRotation;

    public int playerPoints;
    public int playerHealth;

    public int sceneNumber;
}
