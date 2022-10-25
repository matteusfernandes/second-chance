using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Image waterUIBar;
    [SerializeField] private Image woodUIBar;
    [SerializeField] private Image carrotUIBar;

    private PlayerItems playerItems;

    private void Awake()
    {
        playerItems = FindObjectOfType<PlayerItems>();
    }

    void Start()
    {
        waterUIBar.fillAmount = 0f;
        woodUIBar.fillAmount = 0f;
        carrotUIBar.fillAmount = 0f;
    }


    void Update()
    {
        waterUIBar.fillAmount = playerItems.TotalWater / playerItems.limitOfWater;
        woodUIBar.fillAmount = playerItems.TotalWood / playerItems.limitOfWood;
        waterUIBar.fillAmount = playerItems.TotalCarrots / playerItems.limitOfCarrot;
    }
}
