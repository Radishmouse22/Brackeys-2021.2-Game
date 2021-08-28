using UnityEngine;
using UnityEngine.SceneManagement;

public class EndPoint : MonoBehaviour
{
    public bool isRestart = false;

    public void LoadLevel()
    {
        if (isRestart != true)
        {
            LoadNextLevel();
        }
        else
        {
            FindObjectOfType<WorldManager>().LoadLevelAtIndex(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void LoadNextLevel()
    {
        WorldManager manager;
        manager = FindObjectOfType<WorldManager>();

        manager.LoadNextLevel();
    }
}
