using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class navArrow : MonoBehaviour
{
    public Transform target;
    public float rotateSpeed = 0.5f;
    public Transform Nav;  // The arrow that should point towards the target
    public Transform player;  // The player's transform

    void Update()
    {
        if (!target)
        {
            getTarget();
        }
        else
        {
            rotateTowardsTarget();
            moveTowardsTarget();
        }
    }

    private void rotateTowardsTarget()
    {
        Vector2 targetDirection = target.position - Nav.position;
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle));
        Nav.rotation = Quaternion.Slerp(Nav.rotation, targetRotation, rotateSpeed * Time.deltaTime);
    }

    private void moveTowardsTarget()
    {
        // Calculate the direction towards the target
        Vector3 targetDirection = (target.position - player.position).normalized;

        // Offset the Nav position relative to the player's position and axis
        Nav.position = player.position + targetDirection * 3f; // Adjust the multiplier as needed
    }

    private void getTarget()
    {
        GameObject missionObject = GameObject.FindWithTag("Mission");
        if (missionObject != null)
        {
            target = missionObject.transform;
        }
    }
}
