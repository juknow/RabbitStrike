using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationController : MonoBehaviour
{
    private Animator animator;
    public bool isInRange;

    void Start()
    {
        isInRange = false;
        animator = GetComponent<Animator>();

        if (animator == null)
        {
            Debug.LogError("Animator 컴포넌트를 찾을 수 없습니다.");
        }
    }

    void Update()
    {
        if (animator != null)
        {
            animator.SetBool("isInRange", isInRange);
        }
        else
        {
            Debug.LogError("Animator가 초기화되지 않았습니다.");
        }
    }
}
