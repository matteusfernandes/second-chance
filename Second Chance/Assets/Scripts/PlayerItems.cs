using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int totalWood;
    [SerializeField] private float currentWater;

    private float waterLimit = 50;

    public int TotalWood {
        get { return totalWood; }
        set { totalWood = value; }
    }

    public float TotalWater {
        get { return currentWater; }
        set { currentWater = value; }
    }

    public void WaterLimit (float water)
    {
        if (currentWater <= waterLimit)
        {
            currentWater += water;
        }
    }
}
