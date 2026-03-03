using UnityEngine;

/// <summary>
/// Controls player movement
/// </summary>
public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;

    private Rigidbody2D rb;
    private bool isGrounded = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Horizontal movement
        float inputX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        // Jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Touches ground
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        // TODO: If touches a barrel (tag "Barrel"), call LoseLife()
        // Use: PlayerLives.Instance.LoseLife();
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    /// <summary>
    /// TODO: Called when player smashes a barrel with hammer
    /// Add points using ScoreManager.Instance.AddSmashPoints()
    /// </summary>
    public void SmashBarrel()
    {
        // YOUR CODE HERE
    }
}
