using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    private Transform EnemyTransform;
    private List<GameObject> enemiesInRange = new List<GameObject>();

    private float moveSpeed = 5.0f;

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
            GameObject enemy = enemiesInRange[0]; // Get the first enemy that entered the collider
            EnemyTransform = enemy.transform;
            transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            EnemyTransform = enemy.transform;
            transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemiesInRange.Add(other.gameObject); // Add the enemy to the list when it enters the collider
            }
        }
        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Enemy"))
            {
                enemiesInRange.Remove(other.gameObject); // Remove the enemy from the list when it exits the collider
            }
        }

    }
}
