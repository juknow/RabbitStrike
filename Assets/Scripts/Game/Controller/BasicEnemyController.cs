using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortEnemyController : MonoBehaviour
{
    private float myHP, myattack, damageCooldown;
    private bool canTakeDamage;
    private Transform PlayerTransform;
    private List<GameObject> playersInRange = new List<GameObject>();
    private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        //NewDataManager.Instance.LongEnemyCount;
        myHP = NewDataManager.Instance.BasicEnemyHP;
        moveSpeed = NewDataManager.Instance.BasicEnemyMoveSpeed;
        myattack = NewDataManager.Instance.BasicEnemyAttackDamage;
        damageCooldown = NewDataManager.Instance.BasicEnemyAttackCooldown;
        canTakeDamage = true;
    }

    // Update is called once per frame
    void Update()
    {
        //find first coming Enemy. but current system is not following this logic. it may finds first order object.
        /*GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyTransform = enemy.transform;
        transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
        */
        if (playersInRange.Count > 0)
        {
            GameObject closestPlayer = GetClosestPlayer();
            if (closestPlayer != null)
            {
                PlayerTransform = closestPlayer.transform;
                transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                PlayerTransform = player.transform;
                transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, moveSpeed * Time.deltaTime);
            }
        }

        // Die mechanism
        if (myHP <= 0f)
        {
            Debug.Log("기본 적 죽음");
            Destroy(gameObject);
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("PlayerWeapon"))
        {
            Debug.Log("기본적 까이고 있음");
            myHP -= myattack;
        }
    }


    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playersInRange.Remove(other.gameObject); // Remove the enemy from the list when it exits the collider
        }
    }

    GameObject GetClosestPlayer()
    {
        GameObject closestPlayer = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject player in playersInRange)
        {
            float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
            if (distanceToPlayer < closestDistance)
            {
                closestDistance = distanceToPlayer;
                closestPlayer = player;
            }
        }

        return closestPlayer;
    }
}
