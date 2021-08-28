using UnityEngine.SceneManagement;
using UnityEngine;

public class SandboxLevel : MonoBehaviour
{
    private Player player;
    public float lowestPos = -200;

    private void Start()
    {
        player = FindObjectOfType<Player>();
    }

    void Update()
    {
        if (player.transform.position.y <= lowestPos)
        {
            RespawnPlayer();
        }
    }

    private void RespawnPlayer()
    {
        FindObjectOfType<WorldManager>().LoadLevelAtIndex(SceneManager.GetActiveScene().buildIndex);
    }
}
