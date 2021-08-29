using UnityEngine;

public class MoveCamera : MonoBehaviour {

    public Transform player;
    public Camera cam;

    private void Start()
    {
        cam.fieldOfView = PlayerPrefs.GetFloat("FOV", 60f);
    }

    void Update() {
        transform.position = player.transform.position;
    }
}
