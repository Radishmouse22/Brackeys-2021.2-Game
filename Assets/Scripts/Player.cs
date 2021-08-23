using System;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public static Player instance;
    public Animator anim;
    public int swordRange = 4;
    public int swordDamage = 10;

    public TextMeshProUGUI coinsHUD;

    public int coins = 0;

    public Camera cam;

    public int health;
    public int maxHealth = 100;
    public HealthBar healthBar;

    private void SwingSword()
    {
        anim.SetTrigger("Sword");

        RaycastHit hit;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, swordRange))
        {
            if (hit.transform.gameObject.layer == 8)
            {
                if (hit.transform.gameObject.GetComponent<Enemy>() != null)
                {
                    hit.transform.gameObject.GetComponent<Enemy>().health -= swordDamage;
                }
                else
                {
                    Debug.LogError("Enemy does not have enemy script applied");
                }
            }
        }
    }

    public void TakeDamage(int _damage)
    {
        health -= _damage;

        healthBar.SetHealth(health);
    }

    #region boringThings

    private void Start()
    {
        health = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Debug.Log("Instance already exists, destroying player!");
            Destroy(this);
        }
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        coinsHUD.text = $"Coins: {coins}";

        if (Input.GetMouseButtonDown(0))
        {
            SwingSword();
        }
    }

    #endregion
}
