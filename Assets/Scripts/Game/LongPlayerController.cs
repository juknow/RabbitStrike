using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongPlayerController : MonoBehaviour
{
    private Transform EnemyTransform;
    private List<GameObject> enemiesInRange = new List<GameObject>();

    private float moveSpeed = 2.0f;

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
        if (enemiesInRange.Count > 0)
        {
            GameObject closestEnemy = GetClosestEnemy();
            if (closestEnemy != null)
            {
                EnemyTransform = closestEnemy.transform;
                transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (enemy != null)
            {
                EnemyTransform = enemy.transform;
                transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemiesInRange.Remove(other.gameObject); // Remove the enemy from the list when it exits the collider
        }
    }

    GameObject GetClosestEnemy()
    {
        GameObject closestEnemy = null;
        float closestDistance = Mathf.Infinity;

        foreach (GameObject enemy in enemiesInRange)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        return closestEnemy;
    }
}
