using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MenuButton : MonoBehaviour
{
    public GameObject bit;

    private void Start()
    {
        bit.SetActive(false);
    }

    void Update()
    {
        if (EventSystem.current.currentSelectedGameObject == gameObject)
        {
            bit.SetActive(true);
        }
        else
        {
            bit.SetActive(false);
        }
    }
}
