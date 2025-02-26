// Gorney-Alex script

using UnityEngine;

public class PlayerController : GeneralMovements
{
    private void FixedUpdate()
    {
        CheckForWall();
        CheckIfGrounded();

        if (Input.GetKey(KeyCode.W) && isGrounded == true)
        {
            MoveForward();
        }
        if (Input.GetKey(KeyCode.S) && isGrounded == true)
        {
            MoveBackward();
        }
        else
        {
            SlowDown();
        }

        if (Input.GetKey(KeyCode.A) && isGrounded == true)
        {
            RotateLeft();
        }
        else if (Input.GetKey(KeyCode.D) && isGrounded == true)
        {
            RotateRight();
        }
    }

}
