﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public const int maxHealth = 100;
    public int currentHealth = maxHealth;
    public RectTransform healthBar;
 
    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            currentHealth = 0;
            Destroy(gameObject);
            Debug.Log("Dead!");
        }

        healthBar.sizeDelta = new Vector2(currentHealth, healthBar.sizeDelta.y);
    }

}