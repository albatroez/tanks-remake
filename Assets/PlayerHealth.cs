using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currrentHealth;
    public HealthBar healthBar;

    void Start()
    {
        currrentHealth = maxHealth;
        healthBar.SetMaxValue(100);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            TakeDamage(20);
        }
    }

    void TakeDamage(int damage)
    {
        currrentHealth -= damage;
        healthBar.SetHealth(currrentHealth);
    }
}
