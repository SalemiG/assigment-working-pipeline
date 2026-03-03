using UnityEngine;

/// <summary>
/// Controls player (Jumpman/Mario) movement, jumping, and collision detection.
/// Depends on ScoreManager, PlayerLives, and interacts with BarrelController and PlatformController.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float climbSpeed = 3f;
    [SerializeField] private float jumpForce = 12f;
    [SerializeField] private float groundCheckDistance = 0.1f;
    [SerializeField] private LayerMask groundLayer;

    [Header("Player State")]
    [SerializeField] private bool isGrounded = false;
    [SerializeField] private bool isOnLadder = false;
    [SerializeField] private bool hasHammer = false;
    [SerializeField] private float hammerDuration = 10f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private float horizontalInput;
    private float verticalInput;
    private float hammerTimer;
    private ScoreManager scoreManager;
    private PlayerLives playerLives;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        scoreManager = ScoreManager.Instance;
        playerLives = PlayerLives.Instance;
    }

    private void Update()
    {
        // Get input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        // Jump input
        if (Input.GetButtonDown("Jump") && isGrounded && !isOnLadder)
        {
            Jump();
        }

        // TODO: Implement hammer timer countdown
        // If hasHammer is true, decrease hammerTimer
        // When timer reaches 0, call LoseHammer()

        // Update sprite flip based on movement direction
        if (horizontalInput != 0)
        {
            spriteRenderer.flipX = horizontalInput < 0;
        }
    }

    private void FixedUpdate()
    {
        CheckGrounded();

        if (isOnLadder)
        {
            ClimbLadder();
        }
        else
        {
            Move();
        }
    }

    private void Move()
    {
        // Horizontal movement
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
    }

    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        // TODO: Play jump sound effect
        Debug.Log("Player jumped!");
    }

    private void ClimbLadder()
    {
        // TODO: Implement ladder climbing
        // 1. Set rb.gravityScale to 0 while climbing
        // 2. Move player up/down based on verticalInput and climbSpeed
        // 3. Allow horizontal movement at reduced speed
        // 4. If player moves away from ladder, exit climbing mode
    }

    private void CheckGrounded()
    {
        // Simple ground check using raycast
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);
        isGrounded = hit.collider != null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Handle collisions with game objects
        if (collision.CompareTag("Barrel"))
        {
            HandleBarrelCollision(collision.gameObject);
        }
        else if (collision.CompareTag("Ladder"))
        {
            isOnLadder = true;
            rb.gravityScale = 0;
        }
        else if (collision.CompareTag("Hammer"))
        {
            PickupHammer();
            Destroy(collision.gameObject);
        }
        else if (collision.CompareTag("DonkeyKong"))
        {
            // TODO: Handle collision with DonkeyKong (if reachable)
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ladder"))
        {
            isOnLadder = false;
            rb.gravityScale = 1;
        }
    }

    private void HandleBarrelCollision(GameObject barrel)
    {
        if (playerLives == null) return;

        if (hasHammer)
        {
            // Smash barrel with hammer
            SmashBarrel(barrel);
        }
        else if (!playerLives.IsInvincible())
        {
            // Take damage
            TakeDamage();
        }
    }

    private void SmashBarrel(GameObject barrel)
    {
        // TODO: Implement barrel smashing
        // 1. Add points through scoreManager (use AddSmashBarrelPoints)
        // 2. Destroy barrel
        // 3. Play smash effect/sound
        Debug.Log("Barrel smashed!");
    }

    private void TakeDamage()
    {
        // TODO: Implement damage handling
        // 1. Call LoseLife on playerLives
        // 2. If player didn't die, play hurt animation
        // 3. If player died, play death animation and disable controls
        Debug.Log("Player took damage!");
    }

    private void PickupHammer()
    {
        hasHammer = true;
        hammerTimer = hammerDuration;
        // TODO: Add pickup points through scoreManager
        // TODO: Show hammer sprite/animation
        Debug.Log("Hammer picked up!");
    }

    private void LoseHammer()
    {
        hasHammer = false;
        // TODO: Hide hammer sprite/animation
        Debug.Log("Hammer expired!");
    }

    /// <summary>
    /// Called by BarrelController when player jumps over a barrel.
    /// </summary>
    public void OnBarrelJumpedOver()
    {
        if (scoreManager != null)
        {
            scoreManager.AddJumpOverBarrelPoints();
        }
    }

    /// <summary>
    /// Called by PlayerLives system to reset player position after death.
    /// </summary>
    public void ResetToSpawnPoint(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
        rb.velocity = Vector2.zero;
        hasHammer = false;
        // TODO: Reset any active effects/animations
    }

    /// <summary>
    /// Called by PlayerLives to make player blink during invincibility.
    /// </summary>
    public void SetBlinking(bool blinking)
    {
        // TODO: Implement sprite blinking effect
        // Could use coroutine to toggle spriteRenderer.enabled
    }

    public bool HasHammer()
    {
        return hasHammer;
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }
}
