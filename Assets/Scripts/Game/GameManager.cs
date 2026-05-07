using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [Header("Game Settings")]
    [SerializeField] private int maxLives = 3;
    [SerializeField] private float levelTimeLimit = 60f;
    
    [Header("References")]
    private UIManager uiManager;
    private ScoreSystem scoreSystem;
    private LevelManager levelManager;
    
    private int currentLives;
    private float timeRemaining;
    private bool isGameRunning = false;
    private bool levelComplete = false;
    
    public bool IsGameRunning => isGameRunning;
    public int CurrentLives => currentLives;
    public float TimeRemaining => timeRemaining;
    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        scoreSystem = FindObjectOfType<ScoreSystem>();
        levelManager = FindObjectOfType<LevelManager>();
        
        currentLives = maxLives;
        timeRemaining = levelTimeLimit;
        isGameRunning = true;
        
        uiManager?.UpdateLivesDisplay(currentLives);
    }
    
    private void Update()
    {
        if (!isGameRunning || levelComplete)
            return;
        
        // Update timer
        timeRemaining -= Time.deltaTime;
        uiManager?.UpdateTimerDisplay(timeRemaining);
        
        // Check if time's up
        if (timeRemaining <= 0)
        {
            EndGame(false);
        }
    }
    
    public void LoseLife()
    {
        currentLives--;
        uiManager?.UpdateLivesDisplay(currentLives);
        
        if (currentLives <= 0)
        {
            EndGame(false);
        }
    }
    
    public void CollectItem(int points)
    {
        scoreSystem?.AddScore(points);
        AudioManager.Instance?.PlayCollectSound();
    }
    
    public void CompleteLevel()
    {
        levelComplete = true;
        isGameRunning = false;
        uiManager?.ShowWinScreen();
        
        // Auto-load next level after 3 seconds
        Invoke("LoadNextLevel", 3f);
    }
    
    private void EndGame(bool won)
    {
        isGameRunning = false;
        levelComplete = true;
        uiManager?.ShowGameOverScreen();
    }
    
    public void LoadNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }
    
    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
