using UnityEngine;

/// <summary>
/// Controls moving platforms
/// </summary>
public class PlatformController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private bool isMoving = false;
    [SerializeField] private float speed = 2f;
    [SerializeField] private float maxDistance = 3f;

    private Vector3 startPosition;
    private bool moveRight = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (!isMoving) return;

        // TODO: Move the platform back and forth
        // 1. Calculate how far it moved from start position
        // 2. If it moved more than maxDistance, reverse moveRight
        // 3. Move the platform using transform.Translate

        // Hint:
        // float distance = transform.position.x - startPosition.x;
        // transform.Translate(Vector3.right * speed * Time.deltaTime);
    }
}
