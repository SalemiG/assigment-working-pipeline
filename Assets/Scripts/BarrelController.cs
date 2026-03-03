using UnityEngine;

/// <summary>
/// Controls barrel movement
/// </summary>
public class BarrelController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float speed = 3f;
    [SerializeField] private bool moveRight = true;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // TODO: Move the barrel right or left
        // If moveRight is true, move right (positive speed)
        // Otherwise move left (negative speed)
        // Use: rb.velocity = new Vector2(X, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // TODO: If touches a wall (tag "Wall"), reverse direction
        // Change moveRight from true to false or vice versa

        // TODO: If player jumps over the barrel, add points
        // Check if collision.gameObject.CompareTag("Player")
        // Use: ScoreManager.Instance.AddJumpPoints();
    }
}
