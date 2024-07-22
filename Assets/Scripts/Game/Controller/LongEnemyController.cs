using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongEnemyController : MonoBehaviour, IController
{
    private float myHP, myattack, damageCooldown, moveSpeed, closestDistance;
    private bool canTakeDamage, findAnyone;
    private Transform PlayerTransform;
    private List<GameObject> playersInRange = new List<GameObject>();
    private GameObject closestPlayer;
    private AttackAnimationController attackAnimationController;


    // Start is called before the first frame update
    void Start()
    {
        closestPlayer = null;
        findAnyone = true;
        closestDistance = Mathf.Infinity;
        //NewDataManager.Instance.LongEnemyCount;
        myHP = NewDataManager.Instance.LongEnemyHP;
        moveSpeed = NewDataManager.Instance.LongEnemyMoveSpeed;
        myattack = NewDataManager.Instance.LongEnemyAttackDamage;
        damageCooldown = NewDataManager.Instance.LongEnemyAttackCooldown;
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
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
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
                PlayerTransform = closestPlayer.transform;
                transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, moveSpeed * Time.deltaTime);
            }
            else
            {
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (attackAnimationController.isInRange == false)
                {
                    PlayerTransform = player.transform;
                    transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, moveSpeed * Time.deltaTime);
                }
            }
        }


        /*
        if (playersInRange.Count > 0)
        {
            GameObject closestPlayer = GetClosestPlayer();
            if (closestPlayer != null && attackAnimationController.isInRange == false)
            {
                PlayerTransform = closestPlayer.transform;
                transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, moveSpeed * Time.deltaTime);
            }
        }
        else
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null && attackAnimationController.isInRange == false)
            {
                PlayerTransform = player.transform;
                transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, moveSpeed * Time.deltaTime);
            }
        }
        */
        // Die mechanism
        if (myHP <= 0f)
        {
            Debug.Log("롱 적 죽음");
            Destroy(gameObject);
        }
    }


    // 애니메이션 이벤트로 호출할 함수
    public void ApplyDamage()
    {
        if (attackAnimationController.isInRange == true && closestPlayer != null)
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

    void OnTriggerStay2D(Collider2D other)
    {
    }
    /*
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
    */
}
