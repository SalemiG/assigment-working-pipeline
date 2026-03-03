using UnityEngine;

/// <summary>
/// Manages player lives/health system.
/// Works with LevelManager for game over and with GameUI for display.
/// </summary>
public class PlayerLives : MonoBehaviour
{
    public static PlayerLives Instance { get; private set; }

    [Header("Lives Settings")]
    [SerializeField] private int startingLives = 3;
    [SerializeField] private int maxLives = 5;
    [SerializeField] private float respawnDelay = 2f;
    [SerializeField] private Vector3 respawnPosition = new Vector3(0, -4, 0);

    [Header("Invincibility")]
    [SerializeField] private float invincibilityDuration = 2f;
    [SerializeField] private float blinkInterval = 0.1f;

    private int currentLives;
    private bool isInvincible = false;
    private float invincibilityTimer;
    private GameUI gameUI;
    private LevelManager levelManager;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        currentLives = startingLives;
        gameUI = FindObjectOfType<GameUI>();
        levelManager = FindObjectOfType<LevelManager>();
        UpdateLivesDisplay();
    }

    private void Update()
    {
        // TODO: Implement invincibility timer countdown
        // If isInvincible is true, decrease invincibilityTimer
        // When timer reaches 0, set isInvincible to false
    }

    /// <summary>
    /// Called by PlayerController when player takes damage.
    /// Returns true if player died (lives reached 0).
    /// </summary>
    public bool LoseLife()
    {
        if (isInvincible)
        {
            return false; // Can't lose life while invincible
        }

        currentLives--;
        UpdateLivesDisplay();

        Debug.Log($"Player lost a life! Lives remaining: {currentLives}");

        if (currentLives <= 0)
        {
            // TODO: Call GameOver on LevelManager
            return true;
        }
        else
        {
            // TODO: Call Respawn method
            return false;
        }
    }

    /// <summary>
    /// Respawns the player at the starting position with temporary invincibility.
    /// </summary>
    private void Respawn()
    {
        // TODO: Implement respawn logic
        // 1. Wait for respawnDelay seconds (use Invoke or coroutine)
        // 2. Reset player position to respawnPosition
        // 3. Call ActivateInvincibility()
        // 4. Notify LevelManager that respawn is complete
        Debug.Log("Respawn started");
    }

    /// <summary>
    /// Grants temporary invincibility to the player.
    /// </summary>
    public void ActivateInvincibility()
    {
        isInvincible = true;
        invincibilityTimer = invincibilityDuration;
        // TODO: Start player sprite blinking effect
        // This could be done by calling a method on PlayerController
        Debug.Log("Invincibility activated!");
    }

    /// <summary>
    /// Adds an extra life (called when player collects 1-UP or reaches score threshold).
    /// </summary>
    public void AddLife()
    {
        // TODO: Implement this method
        // Increase currentLives (respect maxLives limit)
        // Update display
        // Play sound effect through AudioManager if available
    }

    /// <summary>
    /// Checks if player is currently invincible. Called by PlayerController.
    /// </summary>
    public bool IsInvincible()
    {
        return isInvincible;
    }

    private void UpdateLivesDisplay()
    {
        if (gameUI != null)
        {
            gameUI.UpdateLives(currentLives);
        }
    }

    public int GetCurrentLives()
    {
        return currentLives;
    }

    public void ResetLives()
    {
        currentLives = startingLives;
        isInvincible = false;
        UpdateLivesDisplay();
    }

    public Vector3 GetRespawnPosition()
    {
        return respawnPosition;
    }
}
