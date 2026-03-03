using UnityEngine;

/// <summary>
/// Manages the game score
/// </summary>
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager Instance;

    [Header("Points for actions")]
    [SerializeField] private int barrelJumpPoints = 100;
    [SerializeField] private int barrelSmashPoints = 500;
    [SerializeField] private int levelCompletePoints = 5000;

    private int totalScore = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        totalScore = 0;
    }

    /// <summary>
    /// Adds points when player jumps over a barrel
    /// </summary>
    public void AddJumpPoints()
    {
        totalScore += barrelJumpPoints;
        Debug.Log("Jump points! Total: " + totalScore);
    }

    /// <summary>
    /// TODO: Adds points when player smashes a barrel
    /// Increase totalScore by barrelSmashPoints
    /// </summary>
    public void AddSmashPoints()
    {
        // YOUR CODE HERE
    }

    /// <summary>
    /// TODO: Adds bonus points at the end of level
    /// Increase totalScore by levelCompletePoints
    /// </summary>
    public void AddBonusPoints()
    {
        // YOUR CODE HERE
    }

    public int GetScore()
    {
        return totalScore;
    }
}
