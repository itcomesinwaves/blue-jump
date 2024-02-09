using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 10.0f;
    [SerializeField] private float verticalRange = 10.0f;

    private bool movingUp = true;

    private void Update()
    {
        MoveUpDown();
    }

    private void MoveUpDown()
    {
        // Calculate the vertical movement
        float verticalMovement = movingUp ? moveSpeed : -moveSpeed;

        // Update the enemy's position
        transform.Translate(Vector2.up * verticalMovement * Time.deltaTime);

        // Check if the enemy is out of the vertical range
        if (Mathf.Abs(transform.position.y) >= verticalRange)
        {
            // Change direction
            movingUp = !movingUp;
        }
    }

    // Called when the enemy is shot
    public void OnShot()
    {
        // Add despawning logic here
        // For example, you can play a death animation, disable the GameObject, or destroy it
        Destroy(gameObject);
    }
     private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Enemy hit by projectile");
        // Check if the collided object is a player projectile
        if (other.CompareTag("PlayerProjectile"))
        {
            // Call the OnShot method to handle the enemy being shot
            OnShot();
            // Destroy the projectile upon collision
            Destroy(other.gameObject);
        }
    }


}