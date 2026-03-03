using UnityEngine;

/// <summary>
/// Controls individual barrel behavior: rolling down platforms, collision with player.
/// Spawned by DonkeyKongController. Interacts with PlayerController and ScoreManager.
/// </summary>
[RequireComponent(typeof(Rigidbody2D))]
public class BarrelController : MonoBehaviour
{
    [Header("Barrel Settings")]
    [SerializeField] private float rollSpeed = 3f;
    [SerializeField] private float gravityScale = 2f;
    [SerializeField] private float lifetime = 15f; // Auto-destroy after this time
    [SerializeField] private bool movingRight = true;

    [Header("Jump Detection")]
    [SerializeField] private float jumpDetectionHeight = 1f; // Height above barrel to detect jumps
    [SerializeField] private float jumpDetectionRadius = 1f;
    [SerializeField] private LayerMask playerLayer;

    private Rigidbody2D rb;
    private float aliveTime;
    private bool hasBeenJumpedOver = false;
    private PlayerController player;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = gravityScale;
        player = FindObjectOfType<PlayerController>();

        // Set initial velocity
        SetDirection(movingRight);
    }

    private void Update()
    {
        // Track lifetime and destroy if too old
        aliveTime += Time.deltaTime;
        if (aliveTime >= lifetime)
        {
            Destroy(gameObject);
        }

        // TODO: Check if player jumped over this barrel
        // Use Physics2D.OverlapCircle to detect player above barrel
        // If player is detected and hasn't jumped over this barrel yet:
        //   1. Set hasBeenJumpedOver to true
        //   2. Call player.OnBarrelJumpedOver()
    }

    private void FixedUpdate()
    {
        // Maintain constant horizontal speed
        Vector2 velocity = rb.velocity;
        velocity.x = movingRight ? rollSpeed : -rollSpeed;
        rb.velocity = velocity;

        // TODO: Implement platform edge detection
        // Use raycast downward to detect when barrel reaches platform edge
        // Decide whether barrel should:
        //   - Fall down to lower platform
        //   - Reverse direction
        // This creates more interesting barrel patterns
    }

    /// <summary>
    /// Sets the barrel's movement direction. Called by DonkeyKongController on spawn.
    /// </summary>
    public void SetDirection(bool goingRight)
    {
        movingRight = goingRight;

        // Flip sprite if available
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.flipX = !goingRight;
        }
    }

    /// <summary>
    /// Sets custom speed for this barrel. Called by DonkeyKongController.
    /// </summary>
    public void SetSpeed(float speed)
    {
        rollSpeed = speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Handle collision with platforms and walls
        if (collision.gameObject.CompareTag("Platform"))
        {
            HandlePlatformCollision(collision);
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            ReverseDirection();
        }
    }

    private void HandlePlatformCollision(Collision2D collision)
    {
        // TODO: Implement platform collision logic
        // Determine if barrel hit platform from side or from above
        // If from side, might want to reverse direction
        // If landing from above, just continue rolling
    }

    private void ReverseDirection()
    {
        movingRight = !movingRight;
        // Flip sprite
        SpriteRenderer sprite = GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.flipX = !movingRight;
        }
    }

    /// <summary>
    /// Called by PlayerController when barrel is smashed with hammer.
    /// </summary>
    public void Smash()
    {
        // TODO: Implement barrel destruction
        // 1. Play smash particle effect
        // 2. Play smash sound
        // 3. Destroy this gameObject
        Debug.Log("Barrel was smashed!");
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        // TODO: Optional - spawn barrel debris/particles
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize jump detection area in editor
        Gizmos.color = Color.yellow;
        Vector3 detectionPoint = transform.position + Vector3.up * jumpDetectionHeight;
        Gizmos.DrawWireSphere(detectionPoint, jumpDetectionRadius);
    }
}
