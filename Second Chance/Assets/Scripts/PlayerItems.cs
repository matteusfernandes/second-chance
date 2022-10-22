using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private int totalWood;
    [SerializeField] private float currentWater;
    [SerializeField] private int totalCarrots;

    private float waterLimit = 50;

    public int TotalWood {
        get { return totalWood; }
        set { totalWood = value; }
    }

    public int TotalCarrots {
        get { return totalCarrots; }
        set { totalCarrots = value; }
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
