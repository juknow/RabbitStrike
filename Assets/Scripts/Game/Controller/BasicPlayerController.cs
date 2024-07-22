using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour, IController
{
    private float myHP, myattack, damageCooldown, closestDistance, moveSpeed;
    private bool canTakeDamage, findAnyone;
    private Transform EnemyTransform;
    private List<GameObject> enemiesInRange = new List<GameObject>();
    private GameObject closestEnemy;
    private AttackAnimationController attackAnimationController;


    // Start is called before the first frame update
    void Start()
    {

        closestEnemy = null;
        findAnyone = true;
        closestDistance = Mathf.Infinity;
        //NewDataManager.Instance.LongEnemyCount;
        myHP = NewDataManager.Instance.BasicPlayerHP;
        moveSpeed = NewDataManager.Instance.BasicPlayerMoveSpeed;
        myattack = NewDataManager.Instance.BasicPlayerAttackDamage;
        damageCooldown = NewDataManager.Instance.BasicPlayerAttackCooldown;
        canTakeDamage = true;

        // Get the AttackAnimationController component
        attackAnimationController = GetComponent<AttackAnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Die mechanism
        if (myHP <= 0f)
        {
            Debug.Log("기본 팀 죽음");
            Destroy(gameObject);
            return;
        }
        //find first coming Enemy. but current system is not following this logic. it may finds first order object.
        /*GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyTransform = enemy.transform;
        transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
        */
        // Check if we are in range to attack
        if (findAnyone)
        {
            FindClosestEnemy();

        }

        if (!findAnyone && closestEnemy != null)
        {
            HandleEnemyInteraction();
        }
        else if (!findAnyone && closestEnemy == null)
        {
            ResetEnemySearch();
        }

        /*if (attackAnimationController.isInRange)
        {
            return; // Stop moving if we are in range
        }
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
    }

    void FindClosestEnemy()
    {
        Debug.Log("적 찾는중");
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        closestDistance = Mathf.Infinity; // Reset closest distance for new search
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector2.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < closestDistance)
            {
                closestDistance = distanceToEnemy;
                closestEnemy = enemy;
            }
        }

        // If an enemy is found, stop looking for others
        if (closestEnemy != null)
        {
            findAnyone = false;

        }
    }

    void HandleEnemyInteraction()
    {
        // Check if the closestEnemy has been destroyed
        if (closestEnemy == null)
        {
            ResetEnemySearch();
            return; // Exit early to avoid further processing
        }

        if (!attackAnimationController.isInRange)
        {
            Transform enemyTransform = closestEnemy.transform;
            transform.position = Vector2.MoveTowards(transform.position, enemyTransform.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            // Additional logic for when the enemy is in range can be added here
        }
    }

    void ResetEnemySearch()
    {
        Debug.Log("다시 적 찾기");
        findAnyone = true;
        closestDistance = Mathf.Infinity;
        closestEnemy = null; // Clear the current closest enemy

    }


    // 애니메이션 이벤트로 호출할 함수
    public void ApplyDamage()
    {
        if (attackAnimationController.isInRange && closestEnemy != null)
        {
            var controller = closestEnemy.GetComponent<IController>();
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
        this.transform.Find("Player_Outfit").transform.Find("Body").gameObject.GetComponent<HirEffect>().OnHit();
        this.transform.Find("Player_Outfit").transform.Find("Head").gameObject.GetComponent<HirEffect>().OnHit();
        this.transform.Find("Player_Outfit").transform.Find("Ear1").gameObject.GetComponent<HirEffect>().OnHit();
        this.transform.Find("Player_Outfit").transform.Find("Ear2").gameObject.GetComponent<HirEffect>().OnHit();
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
