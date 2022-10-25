using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlotFarm : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private Sprite hole;
    [SerializeField] private Sprite carrot;
    [SerializeField] private Sprite defaultSprite;

    [Header("Settings")]
    [SerializeField] private int digAmount;
    [SerializeField] private float waterAmount;
    [SerializeField] private bool detecting;

    private int initialDigAmount;
    private float currentWater;
    private bool holeDug;
    private bool grownUp;

    PlayerItems playerItems;

    private void Start()
    {
        playerItems = FindObjectOfType<PlayerItems>();
        initialDigAmount = digAmount;
    }

    private void Update()
    {
        if (holeDug)
        {
            if (detecting)
            {
                currentWater += 0.01f;
            }

            if (currentWater >= waterAmount)
            {
                spriteRenderer.sprite = carrot;
                grownUp = true;
            }
        }
    }

    public void OnHit()
    {
        digAmount--;

        if (digAmount <= initialDigAmount / 2)
        {
            spriteRenderer.sprite = hole;
            holeDug = true;
        }
    }

    public void OnHarvesting()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("apertou E");
        }
        if (grownUp)
        {
            Debug.Log("colheu");
            playerItems.CarrotLimit(1);
            spriteRenderer.sprite = defaultSprite;
            currentWater = 0f;
            initialDigAmount = digAmount;
            grownUp = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Shovel"))
        {
            OnHit();
        }

        if (collision.CompareTag("Water"))
        {
            detecting = true;
        }

        if (collision.CompareTag("Player"))
        {
            if (grownUp)
            {
                playerItems.TotalCarrots ++;
                spriteRenderer.sprite = defaultSprite;
                currentWater = 0f;
                initialDigAmount = digAmount;
                grownUp = false;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Water"))
        {
            detecting = false;
        }
    }
}
