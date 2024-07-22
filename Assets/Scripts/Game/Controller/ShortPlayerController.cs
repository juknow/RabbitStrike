using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShortPlayerController : MonoBehaviour, IController
{
    private float myHP, myattack, damageCooldown, moveSpeed, closestDistance;
    private bool canTakeDamage, findAnyone;

    private Transform EnemyTransform;
    private List<GameObject> enemiesInRange = new List<GameObject>();
    private GameObject closestPlayer;
    private AttackAnimationController attackAnimationController;


    // Start is called before the first frame update
    void Start()
    {
        closestPlayer = null;
        findAnyone = true;
        closestDistance = Mathf.Infinity;
        //NewDataManager.Instance.LongEnemyCount;
        myHP = NewDataManager.Instance.ShortPlayerHP;
        moveSpeed = NewDataManager.Instance.ShortPlayerMoveSpeed;
        myattack = NewDataManager.Instance.ShortPlayerAttackDamage;
        damageCooldown = NewDataManager.Instance.ShortPlayerAttackCooldown;
        canTakeDamage = true;

        // Get the AttackAnimationController component
        attackAnimationController = GetComponent<AttackAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        //find first coming Enemy. but current system is not following this logic. it may finds first order object.
        /*GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyTransform = enemy.transform;
        transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
        */

        if (findAnyone == true)
        {
            GameObject[] players = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject player in players)
            {
                float distanceToPlayer = Vector2.Distance(transform.position, player.transform.position);
                if (distanceToPlayer < closestDistance)
                {
                    closestDistance = distanceToPlayer;
                    closestPlayer = player;
                }
            }

            // If a player is found, stop looking for others
            if (closestPlayer != null)
            {
                findAnyone = false;
            }

        }
        if (findAnyone == false && closestPlayer != null)
        {
            if (attackAnimationController.isInRange == false)
            {
                EnemyTransform = closestPlayer.transform;
                transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                GameObject player = GameObject.FindGameObjectWithTag("Enemy");
                if (attackAnimationController.isInRange == false)
                {
                    EnemyTransform = player.transform;
                    transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
                }
            }
        }


        /*
        if (enemiesInRange.Count > 0)
        {
            GameObject closestEnemy = GetClosestEnemy();
            if (closestEnemy != null && attackAnimationController.isInRange == false)
            {
                EnemyTransform = closestEnemy.transform;
                transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (enemy != null && attackAnimationController.isInRange == false)
            {
                EnemyTransform = enemy.transform;
                transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
            }
        }
        */
        // Die mechanism
        if (myHP <= 0f)
        {
            Debug.Log("숏 적 죽음");
            Destroy(gameObject);
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {

    }


    // 애니메이션 이벤트로 호출할 함수
    public void ApplyDamage()
    {
        if (attackAnimationController.isInRange == true)
        {
            var controller = closestPlayer.GetComponent<IController>();
            if (controller != null)
            {
                controller.ReceiveDamage(myattack);
            }
        }
        // Assuming the target has a method to receive damage

    }
    public void ReceiveDamage(float damage)
    {
        myHP -= damage;
        Debug.Log("Received damage: " + damage + ", HP left: " + myHP);
    }
    /*
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
        */
}
