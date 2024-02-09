using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int collisionsToDie = 4; // Number of collisions before dying
    private int currentHealth;

    private void FixedUpdate() 
    {
        if (gameObject.GetComponent<Transform>().position.y < -50)
        {
            Die();
        }
    }
    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

   

    private void Die()
    {
        // Add logic for player death (e.g., play death animation, show game over screen, etc.)
        // You can implement different death scenarios here based on your game design.
        Debug.Log("Player has died!");
        // Optionally, reset player health for the next attempt
        SceneManager.LoadScene("GameOverMenu");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Decrease the number of collisions the player can withstand
            collisionsToDie--;

            if (collisionsToDie <= 0)
            {
                Die();
            }
            else
            {
                // Optionally, play a hit animation or sound
                Debug.Log("Player got hit! Collisions left: " + collisionsToDie);
            }
        }
    }
}