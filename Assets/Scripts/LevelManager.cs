using UnityEngine;

/// <summary>
/// Manages the level state
/// </summary>
public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [Header("Settings")]
    [SerializeField] private Transform goalPosition; // Where the player needs to reach
    [SerializeField] private float winDistance = 1f;

    private PlayerController player;
    private bool levelActive = true;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (!levelActive) return;

        // TODO: Check if player has reached the goal
        // Calculate the distance between player.transform.position and goalPosition.position
        // If distance is less than winDistance, call LevelComplete()
    }

    /// <summary>
    /// TODO: Called when player wins
    /// 1. Set levelActive = false
    /// 2. Add bonus points with ScoreManager.Instance.AddBonusPoints()
    /// </summary>
    public void LevelComplete()
    {
        // YOUR CODE HERE
        Debug.Log("LEVEL COMPLETE!");
    }

    /// <summary>
    /// Called when player loses all lives
    /// </summary>
    public void GameOver()
    {
        levelActive = false;

        // TODO: Call ShowGameOver() on GameUI
        // Use: FindObjectOfType<GameUI>().ShowGameOver();

        Debug.Log("GAME OVER!");
    }
}
