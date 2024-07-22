using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyRangeController : MonoBehaviour
{
    private AttackAnimationController attackAnimationController;
    // Start is called before the first frame update
    void Start()
    {
        attackAnimationController = GetComponentInParent<AttackAnimationController>();
        Debug.Log(attackAnimationController);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerStay2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지");
            attackAnimationController.isInRange = true;
        }
        else
        {
            Debug.Log("플레이어 감지 해제");
            attackAnimationController.isInRange = false;
        }

    }
}
