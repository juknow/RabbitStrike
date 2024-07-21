using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackAnimationController : MonoBehaviour
{
    private Animator animator;
    public bool isInRange;
    // Start is called before the first frame update
    void Start()
    {
        isInRange = false;
        animator = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            animator.SetBool("isInRange", true);
        }
        else
        {
            animator.SetBool("isInRange", false);
        }
    }

}

