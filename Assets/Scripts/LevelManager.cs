using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Manages the overall level state, win/lose conditions, and level progression.
/// Coordinates between PlayerLives, ScoreManager, and GameUI.
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }

    [Header("Level Settings")]
    [SerializeField] private string nextLevelSceneName = "Level2";
    [SerializeField] private float levelCompleteDelay = 3f;
    [SerializeField] private Transform goalPosition; // Where player needs to reach
    [SerializeField] private float goalDistance = 1f;

    [Header("Level State")]
    [SerializeField] private bool isLevelActive = true;
    [SerializeField] private float levelTimer = 0f;
    [SerializeField] private bool useLevelTimer = false;
    [SerializeField] private float levelTimeLimit = 120f;

    private PlayerController player;
    private ScoreManager scoreManager;
    private PlayerLives playerLives;
    private GameUI gameUI;
    private DonkeyKongController donkeyKong;

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
        // Find all required components
        player = FindObjectOfType<PlayerController>();
        scoreManager = ScoreManager.Instance;
        playerLives = PlayerLives.Instance;
        gameUI = FindObjectOfType<GameUI>();
        donkeyKong = FindObjectOfType<DonkeyKongController>();

        InitializeLevel();
    }

    private void Update()
    {
        if (!isLevelActive) return;

        // TODO: Implement level timer countdown
        // If useLevelTimer is true, decrease levelTimer
        // Update UI with remaining time
        // Call TimeUp() if timer reaches 0

        // TODO: Check if player has reached the goal
        // Use goalPosition and goalDistance to check proximity
        // Call LevelComplete() if player reached goal
    }

    private void InitializeLevel()
    {
        isLevelActive = true;
        levelTimer = levelTimeLimit;

        // Reset all systems
        if (scoreManager != null)
        {
            scoreManager.ResetScore();
        }

        if (playerLives != null)
        {
            playerLives.ResetLives();
        }

        // TODO: Start DonkeyKong barrel throwing
        // Call StartThrowingBarrels() on donkeyKong

        Debug.Log("Level initialized");
    }

    /// <summary>
    /// Called when player reaches the goal (Princess Peach).
    /// </summary>
    public void LevelComplete()
    {
        if (!isLevelActive) return;

        isLevelActive = false;

        Debug.Log("Level Complete!");

        // TODO: Implement level completion
        // 1. Add bonus points through ScoreManager (use AddLevelCompletePoints)
        // 2. Stop DonkeyKong from throwing barrels
        // 3. Show level complete UI (call gameUI.ShowLevelComplete with final score)
        // 4. Load next level after delay (use Invoke with levelCompleteDelay)
    }

    /// <summary>
    /// Called by PlayerLives when player runs out of lives.
    /// </summary>
    public void GameOver()
    {
        // TODO: Implement game over logic
        // 1. Set isLevelActive to false
        // 2. Stop DonkeyKong barrel throwing
        // 3. Get final score from ScoreManager
        // 4. Show game over UI through gameUI
        Debug.Log("Game Over!");
    }

    /// <summary>
    /// Called when level timer runs out.
    /// </summary>
    private void TimeUp()
    {
        Debug.Log("Time's up!");
        // Treat time up as losing a life
        if (playerLives != null)
        {
            playerLives.LoseLife();
        }
    }

    /// <summary>
    /// Restarts the current level.
    /// </summary>
    public void RestartLevel()
    {
        Time.timeScale = 1f; // Resume game if paused
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    /// <summary>
    /// Loads the next level.
    /// </summary>
    private void LoadNextLevel()
    {
        // TODO: Implement next level loading
        // Use SceneManager.LoadScene with nextLevelSceneName
        // Handle case where next level doesn't exist
        Debug.Log($"Loading next level: {nextLevelSceneName}");
    }

    /// <summary>
    /// Checks if player is close enough to goal position.
    /// </summary>
    private bool IsPlayerAtGoal()
    {
        if (player == null || goalPosition == null) return false;

        float distance = Vector3.Distance(player.transform.position, goalPosition.position);
        return distance <= goalDistance;
    }

    public bool IsLevelActive()
    {
        return isLevelActive;
    }

    public float GetTimeRemaining()
    {
        return levelTimer;
    }
}
