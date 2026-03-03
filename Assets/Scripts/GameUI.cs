using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// Manages all UI elements: score display, lives, game over screen, level complete screen.
/// This is the display layer - it receives updates from game systems but doesn't control logic.
/// </summary>
public class GameUI : MonoBehaviour
{
    [Header("UI References")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI multiplierText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject levelCompletePanel;
    [SerializeField] private TextMeshProUGUI finalScoreText;

    [Header("UI Format Strings")]
    [SerializeField] private string scoreFormat = "SCORE: {0:D6}";
    [SerializeField] private string livesFormat = "LIVES: {0}";
    [SerializeField] private string multiplierFormat = "x{0:F1}";

    private void Start()
    {
        // Initialize UI
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);

        UpdateScore(0);
        UpdateLives(3);
        UpdateMultiplier(1.0f);
    }

    /// <summary>
    /// Updates the score display. Called by ScoreManager.
    /// </summary>
    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = string.Format(scoreFormat, score);
        }
    }

    /// <summary>
    /// Updates the lives display. Called by PlayerLives.
    /// </summary>
    public void UpdateLives(int lives)
    {
        if (livesText != null)
        {
            livesText.text = string.Format(livesFormat, lives);
        }
    }

    /// <summary>
    /// Updates the score multiplier display. Called by ScoreManager.
    /// </summary>
    public void UpdateMultiplier(float multiplier)
    {
        // TODO: Implement multiplier display update
        // Show multiplier text only if it's greater than 1.0
        // Hide it if multiplier is 1.0
        if (multiplierText != null)
        {
            // Your code here
        }
    }

    /// <summary>
    /// Shows the game over screen with final score. Called by LevelManager.
    /// </summary>
    public void ShowGameOver(int finalScore)
    {
        // TODO: Implement game over screen display
        // 1. Show gameOverPanel
        // 2. Update finalScoreText with the score
        // 3. Pause the game (Time.timeScale = 0)
        Debug.Log($"Game Over! Final Score: {finalScore}");
    }

    /// <summary>
    /// Shows the level complete screen with final score. Called by LevelManager.
    /// </summary>
    public void ShowLevelComplete(int finalScore)
    {
        // TODO: Implement level complete screen display
        // Similar to ShowGameOver but use levelCompletePanel
        Debug.Log($"Level Complete! Score: {finalScore}");
    }

    /// <summary>
    /// Hides all panels and resumes game. Called by LevelManager when restarting.
    /// </summary>
    public void HideAllPanels()
    {
        if (gameOverPanel != null)
            gameOverPanel.SetActive(false);

        if (levelCompletePanel != null)
            levelCompletePanel.SetActive(false);

        Time.timeScale = 1f;
    }

    /// <summary>
    /// Shows a temporary message on screen (for pickups, combos, etc.)
    /// </summary>
    public void ShowTemporaryMessage(string message, float duration = 2f)
    {
        // TODO: Implement temporary message display
        // This could use a separate TextMeshProUGUI that fades out
        // Or you could create a simple popup effect
        Debug.Log($"UI Message: {message}");
    }

    /// <summary>
    /// Updates the timer display if this is a timed level.
    /// </summary>
    public void UpdateTimer(float timeRemaining)
    {
        // TODO: Optional - implement timer display
        // Format: MM:SS
    }
}
