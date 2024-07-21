using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPlayerRangeController : MonoBehaviour
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

        if (other.CompareTag("Enemy"))
        {
            Debug.Log("적 감지");
            attackAnimationController.isInRange = true;
        }
        else
        {
            //attackAnimationController.isInRange = false;
        }

    }
}
