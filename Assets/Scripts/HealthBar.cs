using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI healthText;

    private Slider slider;

    public void SetHealth(int _health)
    {
        slider.value = _health;
    }

    public void SetMaxHealth(int _health)
    {
        slider.maxValue = _health;
        slider.value = _health;
    }

    #region BoringThings

    private void Start()
    {
        slider = gameObject.GetComponent<Slider>();
    }

    private void Update()
    {
        healthText.text = $"HP: {slider.value}/{slider.maxValue}";
    }

    #endregion
}
