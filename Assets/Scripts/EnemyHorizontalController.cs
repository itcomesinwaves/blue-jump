using UnityEngine;

public class EnemyHorizontalController : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust the speed as needed
    public float movementRange = 5.0f; // Adjust the range as needed
    private bool movingRight = true;
    private int shotAmount = 0;

    private void Update()
    {
        MoveBackAndForth();
    }

    private void MoveBackAndForth()
    {
        float horizontalMovement = movingRight ? moveSpeed : -moveSpeed;
        transform.Translate(Vector2.right * horizontalMovement * Time.deltaTime);

        if (Mathf.Abs(transform.position.x) >= movementRange)
        {
            movingRight = !movingRight;
            FlipSprite();
        }
    }

    private void FlipSprite()
    {
        Vector3 newScale = transform.localScale;
        newScale.x *= -1;
        transform.localScale = newScale;
    }
     public void OnShot()
        {
            // Add despawning logic here
            // For example, you can play a death animation, disable the GameObject, or destroy it
            Destroy(gameObject);
        }
  private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy hit by projectile");
        shotAmount++;
        // Check if the collided object is a player projectile
        if (other.CompareTag("PlayerProjectile"))
        {
            // Call the OnShot method to handle the enemy being shot
            if (shotAmount > 2) 
            {
            OnShot();
            shotAmount = 0;
            }
            // Destroy the projectile upon collision
            Destroy(other.gameObject);
        }
    }

}