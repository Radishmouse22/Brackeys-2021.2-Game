using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public GameObject levelEndPlatform;

    public GameObject deathScreen;

    public List<GameObject> enemies;

    private void Update()
    {
        if (Player.instance.hasDied == true)
        {
            deathScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if (enemies.Count == 0)
        {
            levelEndPlatform.SetActive(true);
        }
    }

    private void Awake()
    {
        enemies = new List<GameObject>(GameObject.FindGameObjectsWithTag("Enemy"));

        levelEndPlatform.SetActive(false);
        deathScreen.SetActive(false);

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
