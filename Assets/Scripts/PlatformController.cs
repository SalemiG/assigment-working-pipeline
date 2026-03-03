using UnityEngine;

/// <summary>
/// Controls platform and ladder behavior.
/// Some platforms might move, break, or have special properties.
/// Interacts with PlayerController for climbing and platform detection.
/// </summary>
public class PlatformController : MonoBehaviour
{
    [Header("Platform Type")]
    [SerializeField] private PlatformType platformType = PlatformType.Static;
    [SerializeField] private bool isLadder = false;

    [Header("Moving Platform Settings")]
    [SerializeField] private float moveSpeed = 2f;
    [SerializeField] private Vector3 moveDistance = new Vector3(3f, 0f, 0f);
    [SerializeField] private bool startMovingRight = true;

    [Header("Breaking Platform Settings")]
    [SerializeField] private float breakDelay = 1f; // Time before platform breaks after being stepped on
    [SerializeField] private float respawnDelay = 5f; // Time before broken platform respawns

    [Header("Conveyor Belt Settings")]
    [SerializeField] private float conveyorSpeed = 2f;
    [SerializeField] private bool conveyorMovingRight = true;

    private Vector3 startPosition;
    private bool movingRight;
    private bool isBroken = false;
    private SpriteRenderer spriteRenderer;
    private Collider2D platformCollider;
    private float breakTimer = 0f;

    public enum PlatformType
    {
        Static,
        Moving,
        Breaking,
        ConveyorBelt
    }

    private void Start()
    {
        startPosition = transform.position;
        movingRight = startMovingRight;
        spriteRenderer = GetComponent<SpriteRenderer>();
        platformCollider = GetComponent<Collider2D>();
    }

    private void Update()
    {
        if (isBroken) return;

        switch (platformType)
        {
            case PlatformType.Moving:
                UpdateMovingPlatform();
                break;
            case PlatformType.Breaking:
                UpdateBreakingPlatform();
                break;
        }
    }

    private void UpdateMovingPlatform()
    {
        // TODO: Implement moving platform logic
        // 1. Move platform back and forth between startPosition and startPosition + moveDistance
        // 2. Use moveSpeed for movement
        // 3. Reverse direction when reaching either end
        // 4. Smoothly ping-pong between positions
    }

    private void UpdateBreakingPlatform()
    {
        // If timer is running, count down to break
        if (breakTimer > 0)
        {
            breakTimer -= Time.deltaTime;

            // TODO: Add visual feedback (shake, change color, flash)

            if (breakTimer <= 0)
            {
                BreakPlatform();
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            HandlePlayerLanded();
        }

        // Apply conveyor belt force
        if (platformType == PlatformType.ConveyorBelt)
        {
            ApplyConveyorForce(collision.gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        // Continue applying conveyor force while player is on belt
        if (platformType == PlatformType.ConveyorBelt && collision.gameObject.CompareTag("Player"))
        {
            ApplyConveyorForce(collision.gameObject);
        }
    }

    private void HandlePlayerLanded()
    {
        if (platformType == PlatformType.Breaking && !isBroken)
        {
            // Start break timer
            breakTimer = breakDelay;
            Debug.Log("Player landed on breaking platform!");
            // TODO: Play warning sound
        }
    }

    private void ApplyConveyorForce(GameObject target)
    {
        // TODO: Implement conveyor belt force
        // Get the Rigidbody2D from target
        // Add horizontal force based on conveyorSpeed and conveyorMovingRight
        // Use AddForce or directly modify velocity
    }

    private void BreakPlatform()
    {
        isBroken = true;

        // TODO: Implement platform breaking
        // 1. Disable collider
        // 2. Play break animation/particle effect
        // 3. Hide sprite or show broken sprite
        // 4. Invoke RespawnPlatform after respawnDelay

        Debug.Log("Platform broke!");
    }

    private void RespawnPlatform()
    {
        // TODO: Implement platform respawn
        // 1. Reset position to startPosition
        // 2. Enable collider
        // 3. Show sprite
        // 4. Set isBroken to false
        // 5. Reset breakTimer to 0

        Debug.Log("Platform respawned!");
    }

    /// <summary>
    /// Called by LevelManager to reset all platforms on level restart.
    /// </summary>
    public void ResetPlatform()
    {
        transform.position = startPosition;
        isBroken = false;
        breakTimer = 0f;

        if (platformCollider != null)
            platformCollider.enabled = true;

        if (spriteRenderer != null)
            spriteRenderer.enabled = true;
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize moving platform path
        if (platformType == PlatformType.Moving)
        {
            Vector3 start = Application.isPlaying ? startPosition : transform.position;
            Vector3 end = start + moveDistance;

            Gizmos.color = Color.cyan;
            Gizmos.DrawLine(start, end);
            Gizmos.DrawWireSphere(start, 0.3f);
            Gizmos.DrawWireSphere(end, 0.3f);
        }

        // Visualize conveyor direction
        if (platformType == PlatformType.ConveyorBelt)
        {
            Gizmos.color = Color.yellow;
            Vector3 center = transform.position;
            Vector3 direction = conveyorMovingRight ? Vector3.right : Vector3.left;
            Gizmos.DrawRay(center, direction * 1.5f);
        }
    }
}
