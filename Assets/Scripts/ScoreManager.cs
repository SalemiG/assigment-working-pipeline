using UnityEngine;

/// <summary>
/// Manages the game score and point values for different actions.
/// This is a singleton that persists across scenes.
/// Other classes will call this to add points when events happen.
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance { get; private set; }

    [Header("Score Settings")]
    [SerializeField] private int jumpOverBarrelPoints = 100;
    [SerializeField] private int smashBarrelPoints = 500;
    [SerializeField] private int collectItemPoints = 300;
    [SerializeField] private int reachTopPoints = 5000;

    [Header("Multiplier Settings")]
    [SerializeField] private float multiplierIncrement = 0.5f;
    [SerializeField] private float multiplierResetTime = 5f;

    private int currentScore = 0;
    private float currentMultiplier = 1.0f;
    private float lastScoreTime;
    private GameUI gameUI;

    private void Awake()
    {
        // Singleton pattern
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        gameUI = FindObjectOfType<GameUI>();
        UpdateScoreDisplay();
    }

    private void Update()
    {
        // TODO: Implement multiplier reset logic
        // If enough time has passed since last score, reset multiplier to 1.0
        // Use multiplierResetTime to determine when to reset
    }

    /// <summary>
    /// Adds points for jumping over a barrel. Called by PlayerController.
    /// </summary>
    public void AddJumpOverBarrelPoints()
    {
        int points = Mathf.RoundToInt(jumpOverBarrelPoints * currentMultiplier);
        currentScore += points;
        IncreaseMultiplier();
        UpdateScoreDisplay();
        Debug.Log($"Jump over barrel! +{points} points (x{currentMultiplier} multiplier)");
    }

    /// <summary>
    /// Adds points for smashing a barrel with hammer. Called by PlayerController.
    /// </summary>
    public void AddSmashBarrelPoints()
    {
        // TODO: Implement this method
        // Similar to AddJumpOverBarrelPoints but use smashBarrelPoints
        // Apply multiplier, increase multiplier, update display
    }

    /// <summary>
    /// Adds points for collecting items (hammer, bonus items). Called by PlayerController.
    /// </summary>
    public void AddCollectItemPoints()
    {
        // TODO: Implement this method
        // Use collectItemPoints value
    }

    /// <summary>
    /// Adds bonus points for reaching the top. Called by LevelManager.
    /// </summary>
    public void AddLevelCompletePoints()
    {
        // TODO: Implement this method
        // Use reachTopPoints value
        // This should be a flat bonus without multiplier
    }

    /// <summary>
    /// Called by other systems to add custom point values.
    /// </summary>
    public void AddPoints(int points, bool applyMultiplier = true)
    {
        if (applyMultiplier)
        {
            points = Mathf.RoundToInt(points * currentMultiplier);
        }
        currentScore += points;
        UpdateScoreDisplay();
        lastScoreTime = Time.time;
    }

    private void IncreaseMultiplier()
    {
        currentMultiplier += multiplierIncrement;
        currentMultiplier = Mathf.Clamp(currentMultiplier, 1.0f, 5.0f);
        lastScoreTime = Time.time;
        // TODO: Update multiplier display on UI
    }

    private void ResetMultiplier()
    {
        currentMultiplier = 1.0f;
        // TODO: Update multiplier display on UI
    }

    private void UpdateScoreDisplay()
    {
        if (gameUI != null)
        {
            gameUI.UpdateScore(currentScore);
        }
    }

    public int GetCurrentScore()
    {
        return currentScore;
    }

    public float GetCurrentMultiplier()
    {
        return currentMultiplier;
    }

    public void ResetScore()
    {
        currentScore = 0;
        ResetMultiplier();
        UpdateScoreDisplay();
    }
}
