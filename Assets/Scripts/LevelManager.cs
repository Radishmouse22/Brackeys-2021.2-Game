using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public List<GameObject> enemies;

    public GameObject pauseScreen;

    public bool isPaused = false;

    private bool playerHasDied = false;

    public void PauseGame()
    {
        isPaused = true;
        pauseScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnPauseGame()
    {
        isPaused = false;
        pauseScreen.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!isPaused)
            {
                PauseGame();
            }
            else if (isPaused)
            {
                UnPauseGame();
            }
        }

        if (Player.instance.hasDied == true)
        {
            if (playerHasDied == false)
            {
                FindObjectOfType<AudioManager>().Play("Die");
            }

            FindObjectOfType<WorldManager>().LoadLevelAtIndex(SceneManager.GetActiveScene().buildIndex);

            playerHasDied = true;
        }
    }

    private void Awake()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));
        pauseScreen.SetActive(false);

        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying levelManager!");
            Destroy(this);
        }
    }
}
