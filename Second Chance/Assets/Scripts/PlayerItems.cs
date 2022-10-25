using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    [Header("Amounts")]
    [SerializeField] private int currentWood;
    [SerializeField] private float currentWater;
    [SerializeField] private int currentCarrots;

    [Header("Limits")]
    [SerializeField] private float waterLimit = 50;
    [SerializeField] private int woodLimit = 5;
    [SerializeField] private int carrotLimit = 10;

    public int TotalWood {
        get { return currentWood; }
        set { currentWood = value; }
    }

    public int TotalCarrots {
        get { return currentCarrots; }
        set { currentCarrots = value; }
    }

    public float TotalWater {
        get => currentWater;
        set => currentWater = value;
    }

    public float limitOfWater {
        get { return waterLimit; }
        set { waterLimit = value; }
    }

    public int limitOfWood {
        get { return woodLimit; }
        set { woodLimit = value; }
    }

    public int limitOfCarrot {
        get { return carrotLimit; }
        set { carrotLimit = value; }
    }

    public void WaterLimit (float water)
    {
        if (currentWater <= waterLimit)
        {
            currentWater += water;
        }
    }

    public void WoodLimit (int wood)
    {
        if (currentWood <= woodLimit)
        {
            currentWood += wood;
        }
    }

    public void CarrotLimit (int carrot)
    {
        if (currentCarrots <= carrotLimit)
        {
            currentCarrots += carrot;
        }
    }
}
