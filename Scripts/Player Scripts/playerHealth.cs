using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class playerHealth : MonoBehaviour
{
    [SerializeField]
    private float health = 100f;

    private PlayerMovement playerMovement;

    [SerializeField] private Slider healthSlider;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    public void TakeDamage(float damageAmount)
    {
        if (health <= 0)
            return;

        health -= damageAmount;

        if (health <= 0f)
        {
            health = 0;

            playerMovement.PlayerDied();

            GameplayController.instance.RestartGame();
        }

        healthSlider.value = health;
    }
}
