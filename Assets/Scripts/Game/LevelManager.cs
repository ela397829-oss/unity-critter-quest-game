using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [Header("Level Settings")]
    [SerializeField] private int levelNumber = 1;
    [SerializeField] private int itemsToCollect = 5;
    [SerializeField] private Vector3 playerSpawnPoint = Vector3.zero;
    
    [Header("Difficulty Settings")]
    [SerializeField] private float levelTimeLimit = 60f;
    [SerializeField] private int numHazards = 3;
    
    private int itemsCollected = 0;
    private GameManager gameManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        
        // Configure based on level
        ConfigureLevel();
    }
    
    private void ConfigureLevel()
    {
        // Adjust difficulty based on level number
        switch (levelNumber)
        {
            case 1:
                levelTimeLimit = 90f;
                numHazards = 2;
                itemsToCollect = 5;
                break;
            case 2:
                levelTimeLimit = 75f;
                numHazards = 4;
                itemsToCollect = 8;
                break;
            case 3:
                levelTimeLimit = 60f;
                numHazards = 6;
                itemsToCollect = 10;
                break;
        }
    }
    
    public void ItemCollected()
    {
        itemsCollected++;
        
        if (itemsCollected >= itemsToCollect)
        {
            gameManager.CompleteLevel();
        }
    }
    
    public int GetItemsCollected() => itemsCollected;
    public int GetItemsToCollect() => itemsToCollect;
}
