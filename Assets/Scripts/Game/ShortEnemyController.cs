using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour
{
    private Transform PlayerTransform;
    private List<GameObject> playersInRange = new List<GameObject>();

    private float moveSpeed = 3.0f;

    // Start is called before the first frame update
    void Start()
    {
        //NewDataManager.Instance.LongEnemyCount;
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
