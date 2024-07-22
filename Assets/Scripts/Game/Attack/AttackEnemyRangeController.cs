using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemyRangeController : MonoBehaviour
{
    private AttackAnimationController attackAnimationController;

    void Start()
    {
        attackAnimationController = GetComponentInParent<AttackAnimationController>();
        if (attackAnimationController == null)
        {
            Debug.LogWarning("AttackAnimationController를 부모 객체에서 찾을 수 없습니다. 장면에서 찾습니다.");
            //attackAnimationController = FindObjectOfType<AttackAnimationController>();
        }

        if (attackAnimationController == null)
        {
            Debug.LogError("AttackAnimationController를 찾을 수 없습니다.");
        }
        else
        {
            Debug.Log("AttackAnimationController가 성공적으로 초기화되었습니다.");
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지");
            if (attackAnimationController != null)
            {
                attackAnimationController.isInRange = true;
            }
            else
            {
                Debug.LogError("AttackAnimationController가 초기화되지 않았습니다.");
            }
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("플레이어 감지 해제");
            if (attackAnimationController != null)
            {
                attackAnimationController.isInRange = false;
            }
            else
            {
                Debug.LogError("AttackAnimationController가 초기화되지 않았습니다.");
            }
        }
    }
}
