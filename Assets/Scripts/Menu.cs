using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public GameObject mainMenu, optionsMenu;

    public GameObject mainFirstButton, optionsFirstButton, optionsClosedButton;

    public GameObject bit;
    public float amountToRotatePerFrame;

    private void Update()
    {
        float z = Mathf.PingPong(Time.time, 1f);
        Vector3 axis = new Vector3(1, 1, z);
        bit.transform.Rotate(axis, 1f);
    }

    private void Start()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);

        // clear selescted object and set it to the play button
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(mainFirstButton);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
