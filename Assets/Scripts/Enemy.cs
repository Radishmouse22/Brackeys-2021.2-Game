using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class Enemy : MonoBehaviour
{
    #region Asighnables

    public Animator anim;

    public Camera playerCamera;
    public GameObject player;

    private NavMeshAgent agent;

    public TextMeshPro healthText;
    public TextMeshPro coinDropText;
    public TextMeshPro strengthText;

    public int health;
    public int maxHealth = 30;

    public int attackRange = 4;
    public float timeBetweenAttacks = 3f;

    public int coinDropAmount = 1;
    public int strength = 2;

    public float countDownSeconds = 5f;

    // Variables for Ranges
    public float willAttackRange = 3f;

    //????
    private bool initAttacking = false;

    #endregion

    public void MoveAgent()
    {
        float _distance = Vector3.Distance(transform.position, player.transform.position);

        if (_distance > willAttackRange)
        {
            agent.isStopped = false;
            agent.SetDestination(player.transform.position);
        }
        else if (agent.isStopped == true)
        {
            return;
        }
        else
        {
            agent.isStopped = true;
            StartCoroutine(AttackPlayer());
        }
    }

    private IEnumerator IncreaseStats()
    {
        coinDropAmount++;
        strength++;

        coinDropText.text = $"Coins: {coinDropAmount}";
        strengthText.text = $"Strength: {strength}";

        yield return new WaitForSeconds(countDownSeconds);

        StartCoroutine(IncreaseStats());
    }

    private IEnumerator AttackPlayer()
    {
        anim.SetTrigger("Sword");

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, attackRange))
        {
            if (hit.transform.gameObject.layer == 7)
            {
                if (hit.transform.gameObject.GetComponent<Player>() != null)
                {
                    hit.transform.gameObject.GetComponent<Player>().TakeDamage(strength);
                }
                else
                {
                    Debug.LogError("Player does not have player script applied");
                }
            }
        }

        yield return new WaitForSeconds(timeBetweenAttacks);
        if (agent.isStopped == true)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    private void VeiwStats(TextMeshPro _object)
    {
        _object.transform.LookAt(playerCamera.transform);
        _object.transform.rotation = Quaternion.LookRotation(playerCamera.transform.forward);
    }

    private void Die()
    {
        Debug.Log($"An enemy was killed, you received {coinDropText} coins");
        Player.instance.coins += coinDropAmount;

        Destroy(gameObject);
        Debug.Log("Enemy was destroyed");
    }

    #region boringThings

    private void Start()
    {
        StartCoroutine(IncreaseStats());
        agent = gameObject.GetComponent<NavMeshAgent>();
        health = maxHealth;
    }
    private void Update()
    {
        MoveAgent();
        healthText.text = $"Health: {health}";

        if (health <= 0)
        {
            Die();
        }
    }

    void LateUpdate()
    {
        VeiwStats(coinDropText);
        VeiwStats(strengthText);
        VeiwStats(healthText);
    }

    #endregion
}
