using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navArrow : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 0.25f;
    public Transform Nav;

    public void Update()
    {
        if (!target)
        {
            getTarget();
        }
        else
        {
            rotateTowrdsTarget();
        }
        
    }
    private void rotateTowrdsTarget()
    {
        Vector2 targetDirection = target.position - transform.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion q = Quaternion.Euler(new Vector3(0, 0, angle));
        transform.localRotation = Quaternion.Slerp(transform.localRotation, q, rotateSpeed);
    }

    private void getTarget()
    {
      GameObject  missionObject = GameObject.FindWithTag("Mission");
        if (missionObject != null)
        {
            target = missionObject.transform;
        }
    }
}
