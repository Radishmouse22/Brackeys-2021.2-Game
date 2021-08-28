using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class WorldManager : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    public GameObject coin;

    private void Update()
    {
        if (coin == null)
        {
            return;
        }
        else
        {
            coin.transform.Rotate(0f, 0f, 2f);
        }
    }

    // Load the next Scene in the build settings
    // If it doesn't exist it loads the first Scene
    public void LoadNextLevel()
    {
        int nextScene = SceneManager.GetActiveScene().buildIndex + 1;

        StartCoroutine(LoadLevel(nextScene));
    }

    // Loads a Scene at a certain buildindex
    public void LoadLevelAtIndex(int index)
    {
        try
        {
            StartCoroutine(LoadLevel(index));
        }
        catch
        {
            Debug.LogError($"Tryed to load a Scene at buildindex {index} which doesn't exist (WorldManager.LoadLevelAtIndex)");
        }

    }

    private IEnumerator LoadLevel(int index)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(index);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
