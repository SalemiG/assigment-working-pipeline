using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Manages the user interface display
/// </summary>
public class GameUI : MonoBehaviour
{
    [Header("UI Texts")]
    [SerializeField] private Text scoreText;
    [SerializeField] private Text livesText;

    [Header("Panels")]
    [SerializeField] private GameObject gameOverPanel;

    private void Start()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);
    }

    /// <summary>
    /// Updates the score text
    /// </summary>
    public void UpdateScore(int score)
    {
        if (scoreText != null)
            scoreText.text = "SCORE: " + score;
    }

    /// <summary>
    /// TODO: Updates the lives text
    /// Set livesText.text with the number of lives (format: "LIVES: X")
    /// </summary>
    public void UpdateLives(int lives)
    {
        // YOUR CODE HERE
    }

    /// <summary>
    /// TODO: Shows the game over panel
    /// Activate gameOverPanel with SetActive(true)
    /// </summary>
    public void ShowGameOver()
    {
        // YOUR CODE HERE
    }
}
