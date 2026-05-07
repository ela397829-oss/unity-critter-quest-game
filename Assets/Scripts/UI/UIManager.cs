using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI livesText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject winPanel;
    [SerializeField] private GameObject pausePanel;
    
    [Header("Buttons")]
    [SerializeField] private Button restartButton;
    [SerializeField] private Button menuButton;
    [SerializeField] private Button nextLevelButton;
    [SerializeField] private Button pauseButton;
    [SerializeField] private Button resumeButton;
    
    private GameManager gameManager;
    private bool isPaused = false;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        // Setup button listeners
        if (restartButton) restartButton.onClick.AddListener(() => gameManager.RestartLevel());
        if (menuButton) menuButton.onClick.AddListener(() => gameManager.LoadMainMenu());
        if (nextLevelButton) nextLevelButton.onClick.AddListener(() => gameManager.LoadNextLevel());
        if (pauseButton) pauseButton.onClick.AddListener(TogglePause);
        if (resumeButton) resumeButton.onClick.AddListener(TogglePause);
        
        // Hide panels initially
        if (gameOverPanel) gameOverPanel.SetActive(false);
        if (winPanel) winPanel.SetActive(false);
        if (pausePanel) pausePanel.SetActive(false);
    }
    
    public void UpdateScoreDisplay(int score)
    {
        if (scoreText)
            scoreText.text = "Score: " + score;
    }
    
    public void UpdateLivesDisplay(int lives)
    {
        if (livesText)
            livesText.text = "Lives: " + lives;
    }
    
    public void UpdateTimerDisplay(float timeRemaining)
    {
        if (timerText)
        {
            int seconds = Mathf.Max(0, Mathf.CeilToInt(timeRemaining));
            timerText.text = "Time: " + seconds + "s";
            
            // Change color if time is running out
            if (timeRemaining < 10f)
                timerText.color = Color.red;
            else
                timerText.color = Color.white;
        }
    }
    
    public void ShowGameOverScreen()
    {
        if (gameOverPanel)
            gameOverPanel.SetActive(true);
    }
    
    public void ShowWinScreen()
    {
        if (winPanel)
            winPanel.SetActive(true);
    }
    
    public void TogglePause()
    {
        isPaused = !isPaused;
        
        if (pausePanel)
            pausePanel.SetActive(isPaused);
        
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
