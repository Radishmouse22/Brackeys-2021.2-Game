using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;

    public GameObject mainFirstButton, optionsFirstButton, optionsClosedButton;

    public GameObject bit;

    private GameObject objectSelected;

    public TextMeshProUGUI coinsTotal;

    private void Update()
    {
        if (EventSystem.current.currentSelectedGameObject != objectSelected)
        {
            int soundToPlay;
            soundToPlay = Random.Range(1, 4);

            Debug.Log(soundToPlay);

            FindObjectOfType<AudioManager>().Play($"Select{soundToPlay}");
        }

        float z = Mathf.PingPong(Time.time, 1f);
        Vector3 axis = new Vector3(1, 1, z);
        bit.transform.Rotate(axis, 1f);

        objectSelected = EventSystem.current.currentSelectedGameObject;
    }

    private void Start()
    {
        coinsTotal.text = PlayerPrefs.GetInt("Coins", 0).ToString();

        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        // clear selescted object and set it to the play button
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }
    
    public void PlayGame()
    {
        PlayerPrefs.SetInt("Coins", 0);
        FindObjectOfType<WorldManager>().LoadLevelAtIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenOptions()
    {
        optionsMenu.SetActive(true);
        mainMenu.SetActive  (false);

        // clear selescted object and set it to the play button
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsFirstButton);
    }
    public void CloseOptions()
    {
        mainMenu.SetActive    (true);
        optionsMenu.SetActive(false);

        // clear selescted object and set it to the play button
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(optionsClosedButton);
    }
}
