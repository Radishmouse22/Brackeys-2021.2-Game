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
    public int swordRange = 4, swordDamage = 10;
    private bool isSwingingSword;
    public float swordCooldownTime = 0.4f;

    // Coin Count
    public int coins = 0;
    public TextMeshProUGUI coinsHUD;

    // Player Health
    public int health, maxHealth = 100;
    public HealthBar healthBar;

    // Player death
    [HideInInspector]
    public bool hasDied = false;

    // Enemy strength increase timer
    public int countdown = 20;
    public TextMeshProUGUI countdownDisplay;

    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<EndPoint>() != null)
        {
            other.GetComponent<EndPoint>().LoadLevel();
        }
    }

    public IEnumerator RestartCountdown()
    {
        countdown = 20;

        foreach (GameObject enemy in LevelManager.instance.enemies)
        {
            enemy.GetComponent<Enemy>().IncreaseStats();
        }

        yield return new WaitForSeconds(20f);
        StartCoroutine(RestartCountdown());
    }

    public IEnumerator UpdateCountdown(float delay = 0.0f)
    {
        if (delay != 0)
            yield return new WaitForSeconds(delay);

        countdown--;
        countdownDisplay.text = countdown.ToString();

        yield return new WaitForSeconds(1f);
        StartCoroutine(UpdateCountdown());
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

        StartCoroutine(RestartCountdown());
        StartCoroutine(UpdateCountdown(1f));
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
            coinsHUD.text = coins.ToString();

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
