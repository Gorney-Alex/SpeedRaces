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
        const int raycastDistanceLeftRight = 7;
        const int raycastDistanceFoward = 10;
        Debug.DrawRay(transform.position, transform.right * raycastDistanceLeftRight, Color.red);
        Debug.DrawRay(transform.position, -transform.right * raycastDistanceLeftRight, Color.red);

        Debug.DrawRay(transform.position, -transform.up * raycastDistanceFoward, Color.blue);

        if (Physics.Raycast(transform.position, transform.right, raycastDistanceLeftRight))
        {
            RotateLeft();
            Debug.Log("Left");
        }
        else if (Physics.Raycast(transform.position, -transform.right, raycastDistanceLeftRight))
        {
            RotateRight();
            Debug.Log("Right");
        }

        if (Physics.Raycast(transform.position, -transform.up, raycastDistanceFoward))
        {
            MoveBackward();
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
