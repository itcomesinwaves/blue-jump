
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private int maxJumps = 2;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private GameObject projectilePrefab;
  
    private Rigidbody2D body;
    private Animator animator;
    private int jumps;
    private bool isGoingRight = true;
    [SerializeField][Range(0.0f, 100f)] public float shootDistance = 5.0f;
    [SerializeField][Range(0.0f, 100f)] public float shootStrength = 20.0f;
    [SerializeField][Range(0.0f, 100f)] public float firingRate = 10.0f;
    private bool isFiring = false;
   
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        HandleShooting();
        HandleMovement();
        HandleJump();
    }

    private void HandleMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        body.velocity = new Vector2(horizontalInput * speed, body.velocity.y);

        FlipSprite(horizontalInput);
    }
    public void OnCollisionEnter2D(Collision2D collider) 
    {
        if (collider.gameObject.tag == "Ground") 
        {
            animator.SetBool("IsJumping", false);
            jumps = 0;
        }
    }
    private void HandleJump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (IsGrounded() || jumps < maxJumps)
            {
                jumps++;
                Jump();
            }
        }
    }
    private void HandleShooting() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Shoot();
        }
    } 
 

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, 5.0f, groundLayer);
        return hit.collider != null;
    }

    private void Jump()
    {
        
        body.velocity = new Vector2(body.velocity.x, jumpForce);
        animator.SetBool("IsJumping", true);
    }

public void Shoot()
{
    // Instantiate the projectile at the spawn point
    isFiring = Input.GetButton("Fire1");

    if (isFiring)
    {
        GameObject projectile = Instantiate(
            projectilePrefab,
            new Vector3(
                gameObject.transform.position.x + (isGoingRight ? 1 : -1) * shootDistance,
                gameObject.transform.position.y,
                gameObject.transform.position.z),
            Quaternion.identity
        );
        
        Rigidbody2D projectileRb = projectile.GetComponent<Rigidbody2D>();
        projectileRb.AddForce(new Vector3(isGoingRight ? shootStrength : -shootStrength, 0, 0));

        // Set the projectile's tag to "PlayerProjectile" for identification
        projectile.tag = "PlayerProjectile";
        // Destroy the projectile after a specified delay (e.g., 2 seconds)
        Destroy(projectile, 1.0f);
    }
}

    public void FlipSprite(float horizontalInput)
    {
        if (horizontalInput > 0)
        {
            isGoingRight = true;
            transform.localScale = new Vector3(3.63f, 3.34f, 1);
            animator.SetBool("IsRunning", true);
        }
        else if (horizontalInput < 0)
        {
            isGoingRight = false;
            transform.localScale = new Vector3(-3.63f, 3.34f, 1);
            animator.SetBool("IsRunning", true);
        }
        else
        {
            body.velocity = new Vector2(Mathf.Lerp(body.velocity.x, 0, 0.1f), body.velocity.y);
            animator.SetBool("IsRunning", false);
        }
    }
    
}
