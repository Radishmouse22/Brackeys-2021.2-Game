using System.Collections;
using UnityEngine;
using TMPro;

public class Enemy : MonoBehaviour
{
    public Camera playerCamera;

    public TextMeshPro coinDropText;
    public TextMeshPro strengthText;

    public int coinDropAmount = 1;
    public int strength = 2;

    public int countDownSeconds = 5;

    private IEnumerator IncreaseStats()
    {
        coinDropAmount++;
        strength++;

        coinDropText.text = coinDropAmount.ToString();
        strengthText.text = strength.ToString();

        yield return new WaitForSeconds(countDownSeconds);

        StartCoroutine(IncreaseStats());
    }

    private void VeiwStats(TextMeshPro _object)
    {
        _object.transform.LookAt(playerCamera.transform);
        _object.transform.rotation = Quaternion.LookRotation(playerCamera.transform.forward);
    }

    #region boringThings

    private void Start()
    {
        StartCoroutine(IncreaseStats());
    }

    void LateUpdate()
    {
        VeiwStats(coinDropText);
        VeiwStats(strengthText);
    }

    #endregion
}
