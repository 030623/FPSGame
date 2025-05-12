using UnityEngine;
using UnityEngine.UI;

public class PlayerStateUI : MonoBehaviour
{
    public Slider healthSlider;

    public Image fillImage;

    public Gradient healthGradient;
    private void Start()
    {
        healthSlider.maxValue = Player.instance.maxHealth;
        healthSlider.value = Player.instance.health;
        fillImage.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }

    private void Update()
    {
        healthSlider.value = Player.instance.health;
        fillImage.color = healthGradient.Evaluate(healthSlider.normalizedValue);
    }
}
