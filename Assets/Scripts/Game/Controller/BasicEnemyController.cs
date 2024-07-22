using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ShortEnemyController : MonoBehaviour, IController
{
    private float myHP, myattack, damageCooldown, closestDistance;
    private bool canTakeDamage, findAnyone;
    private Transform PlayerTransform;
    private List<GameObject> playersInRange = new List<GameObject>();
    private float moveSpeed;
    private GameObject closestPlayer;

    private AttackAnimationController attackAnimationController;

    // Start is called before the first frame update
    void Start()
    {
        closestPlayer = null;
        findAnyone = true;
        closestDistance = Mathf.Infinity;
        //NewDataManager.Instance.LongEnemyCount;
        myHP = NewDataManager.Instance.BasicEnemyHP;
        moveSpeed = NewDataManager.Instance.BasicEnemyMoveSpeed;
        myattack = NewDataManager.Instance.BasicEnemyAttackDamage;
        damageCooldown = NewDataManager.Instance.BasicEnemyAttackCooldown;
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
            Debug.Log("기본 적 죽음");
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
        StartCoroutine(DamageEffect());
    }

    private IEnumerator DamageEffect()
    {
        Transform outfitTransform = this.transform.Find("Player_Outfit");
        outfitTransform.Find("Body").GetComponent<SpriteRenderer>().color = Color.red;
        outfitTransform.Find("Head").GetComponent<SpriteRenderer>().color = Color.red;
        outfitTransform.Find("Ear1").GetComponent<SpriteRenderer>().color = Color.red;
        outfitTransform.Find("Ear2").GetComponent<SpriteRenderer>().color = Color.red;

        yield return new WaitForSeconds(0.3f);

        outfitTransform.Find("Body").GetComponent<SpriteRenderer>().color = Color.black;
        outfitTransform.Find("Head").GetComponent<SpriteRenderer>().color = Color.black;
        outfitTransform.Find("Ear1").GetComponent<SpriteRenderer>().color = Color.black;
        outfitTransform.Find("Ear2").GetComponent<SpriteRenderer>().color = Color.black;
    }
}

