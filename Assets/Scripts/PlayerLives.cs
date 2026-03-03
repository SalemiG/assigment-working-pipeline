using UnityEngine;

/// <summary>
/// Manages player lives
/// </summary>
public class PlayerLives : MonoBehaviour
{
    public static PlayerLives Instance;

    [Header("Lives settings")]
    [SerializeField] private int startingLives = 3;

    private int currentLives;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        currentLives = startingLives;
    }

    /// <summary>
    /// Player loses a life
    /// </summary>
    public void LoseLife()
    {
        currentLives--;
        Debug.Log("Life lost! Lives remaining: " + currentLives);

        // TODO: If lives are 0 or less, call GameOver() on LevelManager
        // Use: LevelManager.Instance.GameOver();
    }

    /// <summary>
    /// TODO: Adds an extra life (maximum 5 lives)
    /// Increase currentLives by 1, but don't exceed 5
    /// </summary>
    public void AddLife()
    {
        // YOUR CODE HERE
    }

    public int GetLives()
    {
        return currentLives;
    }
}
