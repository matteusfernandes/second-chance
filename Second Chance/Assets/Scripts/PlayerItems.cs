using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    public int currentWood;
    public int currentCarrots;
    public float currentWater;
    public int currentFishes;

    [Header("Limits")]
    public float waterLimit = 50;
    public float carrotLimit = 10;
    public float woodLimit = 5;
    public float fishesLimit = 3;


    public void WaterLimit (float water)
    {
        if (currentWater <= waterLimit)
        {
            currentWater += water;
        }
    }
}
