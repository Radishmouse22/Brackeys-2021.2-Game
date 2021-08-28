using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    public TextMeshProUGUI healthText;

    public Slider slider;

    public void SetHealth(int _health)
    {
        slider.value = _health;
    }

    public void SetMaxHealth(int _health)
    {
        slider.maxValue = _health;
        slider.value = _health;
    }

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        healthText.text = $"{slider.value}/{slider.maxValue}";
    }
}
