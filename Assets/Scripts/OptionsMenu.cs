using UnityEngine;
using UnityEngine.UI;

public class OptionsMenu : MonoBehaviour
{
    // The Sliders
    public Slider FOV, sensitivity;

    private void Start()
    {
        LoadSettings();
    }

    public void LoadSettings()
    {
        FOV.value = PlayerPrefs.GetFloat("FOV");
        sensitivity.value = PlayerPrefs.GetFloat("sens");
    }

    public void UpdateSettings()
    {
        PlayerPrefs.SetFloat("FOV", FOV.value);
        PlayerPrefs.SetFloat("sens", sensitivity.value);
    }
}
