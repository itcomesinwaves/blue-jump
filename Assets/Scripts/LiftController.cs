using System.Collections;
using UnityEngine;

public class LiftController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 2.0f;
    [SerializeField] private float minHeight = 0.0f;
    [SerializeField] private float maxHeight = 5.0f;

    private bool movingUp = true;

    private void Update()
    {
        MoveUpDown();
    }

    private void MoveUpDown()
    {
        // Calculate the vertical movement
        float verticalMovement = movingUp ? moveSpeed : -moveSpeed;

        // Update the lift's position
        transform.Translate(Vector2.up * verticalMovement * Time.deltaTime);

        // Check if the lift is out of the vertical range
        if (transform.position.y >= maxHeight)
        {
            // Change direction to move down
            movingUp = false;
        }
        else if (transform.position.y <= minHeight)
        {
            // Change direction to move up
            movingUp = true;
        }
    }
}
