using UnityEngine;

public class ScoreSystem : MonoBehaviour
{
    private int currentScore = 0;
    private UIManager uiManager;
    
    public int CurrentScore => currentScore;
    
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
        currentScore = 0;
        uiManager?.UpdateScoreDisplay(currentScore);
    }
    
    public void AddScore(int points)
    {
        currentScore += points;
        uiManager?.UpdateScoreDisplay(currentScore);
    }
    
    public void ResetScore()
    {
        currentScore = 0;
        uiManager?.UpdateScoreDisplay(currentScore);
    }
}
