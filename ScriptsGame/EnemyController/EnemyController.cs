using UnityEngine;

public class EnemyController : GeneralMovements
{
    private void FixedUpdate()
    {
        CheckForWall();
        CheckWay();
        MoveEnemyAlgoritm();
        SlowDown();
    }

    private void MoveEnemyAlgoritm()
    {
        CheckIfGrounded();
        if (isGrounded)
        {
            MoveForward();
        }
    }

    private void CheckWay()
    {
        const int raycastDistance = 7;
        Debug.DrawRay(transform.position, transform.right * raycastDistance, Color.red);
        Debug.DrawRay(transform.position, -transform.right * raycastDistance, Color.red);

        if (Physics.Raycast(transform.position, transform.right, raycastDistance))
        {
            RotateLeft();
            Debug.Log("Left");
        }
        else if (Physics.Raycast(transform.position, -transform.right, raycastDistance))
        {
            RotateRight();
            Debug.Log("Right");
        }
    }


    // public void MoveTowardsTarget()
    // {
    //     Vector3 nextPointPosition = wayPoints[currentTargetIndex].transform.position;
    //     Vector3 directionToTarget = (nextPointPosition - enemyRigibody.position).normalized;

    //     currentSpeed = Mathf.Lerp(currentSpeed, maxSpeed, Time.deltaTime * acceleration);

    //     Vector3 newPositionEnemy = enemyRigibody.position + directionToTarget * currentSpeed * Time.deltaTime;
    //     enemyRigibody.MovePosition(newPositionEnemy);
    //     if (Vector3.Distance(enemyRigibody.position, nextPointPosition) < stopDistance)
    //     {
    //         currentTargetIndex++;
    //         if (currentTargetIndex >= wayPoints.Length) 
    //         {
    //             currentTargetIndex = 0;
    //         }
    //     }
    // }
}
