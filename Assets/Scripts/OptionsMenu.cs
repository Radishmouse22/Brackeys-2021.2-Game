using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    // The Sliders
    public Slider FOV, sensitivity;
    public TextMeshProUGUI FOVText, sensitivityText;

    public float FOVMin = 20f;
    public float FOVMax = 160f;
    public float sensMin = 30f;
    public float sensMax = 90f;

    private void Start()
    {
        FOV.minValue = FOVMin;
        FOV.maxValue = FOVMax;

        sensitivity.minValue = sensMin;
        sensitivity.maxValue = sensMax;

        LoadSettings();
    }

    private void Update()
    {
        FOVText.text = Mathf.Round(FOV.value).ToString();
        sensitivityText.text = Mathf.Round(sensitivity.value).ToString();
    }

    public void LoadSettings()
    {
        FOV.value = PlayerPrefs.GetFloat("FOV", 60f);
        sensitivity.value = PlayerPrefs.GetFloat("sens", 50f);
    }

    public void UpdateSettings()
    {
        PlayerPrefs.SetFloat("FOV", FOV.value);
        PlayerPrefs.SetFloat("sens", sensitivity.value);
    }
}
