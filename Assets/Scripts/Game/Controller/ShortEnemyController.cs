using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyController : MonoBehaviour, IController
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
        myHP = NewDataManager.Instance.ShortEnemyHP;
        moveSpeed = NewDataManager.Instance.ShortEnemyMoveSpeed;
        myattack = NewDataManager.Instance.ShortEnemyAttackDamage;
        damageCooldown = NewDataManager.Instance.ShortEnemyAttackCooldown;
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
            Debug.Log("숏 적 죽음");
            Destroy(gameObject);
        }
        //find first coming Enemy. but current system is not following this logic. it may finds first order object.
        /*GameObject enemy = GameObject.FindGameObjectWithTag("Enemy");
        EnemyTransform = enemy.transform;
        transform.position = Vector2.MoveTowards(transform.position, EnemyTransform.position, moveSpeed * Time.deltaTime);
        */

        if (findAnyone)
        {
            FindClosestPlayer();
        }

        if (!findAnyone && closestPlayer != null)
        {
            HandlePlayerInteraction();
        }
        else if (!findAnyone && closestPlayer == null)
        {
            ResetPlayerSearch();
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
    }
    void FindClosestPlayer()
    {
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        closestDistance = Mathf.Infinity; // Reset closest distance for new search
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

    void HandlePlayerInteraction()
    {
        // Check if the closestPlayer has been destroyed
        if (closestPlayer == null)
        {
            ResetPlayerSearch();
            return; // Exit early to avoid further processing
        }

        if (!attackAnimationController.isInRange)
        {
            Transform playerTransform = closestPlayer.transform;
            transform.position = Vector2.MoveTowards(transform.position, playerTransform.position, moveSpeed * Time.deltaTime);
        }
        else
        {

            // Additional logic for when the player is in range can be added here
        }
    }

    void ResetPlayerSearch()
    {
        findAnyone = true;
        closestDistance = Mathf.Infinity;
        closestPlayer = null;
    }


    // 애니메이션 이벤트로 호출할 함수
    public void ApplyDamage()
    {
        if (attackAnimationController.isInRange && closestPlayer != null)
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
        this.transform.Find("Player_Outfit").transform.Find("Body").gameObject.GetComponent<HirEffect>().OnHit();
        this.transform.Find("Player_Outfit").transform.Find("Head").gameObject.GetComponent<HirEffect>().OnHit();
        this.transform.Find("Player_Outfit").transform.Find("Ear1").gameObject.GetComponent<HirEffect>().OnHit();
        this.transform.Find("Player_Outfit").transform.Find("Ear2").gameObject.GetComponent<HirEffect>().OnHit();
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
