using System.Collections;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    #region Assignables

    // Basic Player attributes
    public static Player instance;
    public Animator anim;
    public Camera cam;

    // Sword data
    public int swordRange = 4;
    public int swordDamage = 10;
    private bool isSwingingSword;
    public float swordCooldownTime = 0.4f;

    // Coin Count
    public int coins = 0;
    public TextMeshProUGUI coinsHUD;

    // Player Health
    public int health;
    public int maxHealth = 100;
    public HealthBar healthBar;

    // Player death
    [HideInInspector]
    public bool hasDied = false;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EndPoint>() != null)
        {
            other.GetComponent<EndPoint>().LoadNextLevel();
        }
    }

    private void SwingSword()
    {
        if (isSwingingSword == false)
        {
            isSwingingSword = true;

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

            Invoke("SwordCooldown", swordCooldownTime);
        }
    }

    private void SwordCooldown()
    {
        isSwingingSword = false;
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
        if (hasDied != true)
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

            if (health <= 0)
            {
                hasDied = true;
            }
        }
    }

    #endregion
}
