using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyStateUI : MonoBehaviour
{
    public Enemy enemy;

    public Slider healthSlider;

    public Image fillImage;

    public Gradient healthGradient;
    private void Start()
    {
        healthSlider.maxValue = enemy.maxHealth;
        healthSlider.value = enemy.health;
        fillImage.color = healthGradient.Evaluate(healthSlider.normalizedValue);


    }

    private void Update()
    {
        healthSlider.value = enemy.health;
        fillImage.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
