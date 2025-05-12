using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance;
    public float health = 100;
    public float maxHealth = 100;
    private void Awake()
    {
        instance = this;

        health = maxHealth;
    }

    

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        GameManager.Instance.GameFailEnd();
    }
}
