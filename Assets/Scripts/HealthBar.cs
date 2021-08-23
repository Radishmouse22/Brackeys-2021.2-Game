using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    public void SetHealth(int _health)
    {
        slider.value = _health;
    }

    public void SetMaxHealth(int _health)
    {
        slider.maxValue = _health;
        slider.value = _health;
    }
}
