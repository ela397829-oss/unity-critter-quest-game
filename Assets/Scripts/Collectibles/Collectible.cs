using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] private int pointsValue = 10;
    
    private GameManager gameManager;
    private LevelManager levelManager;
    
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        levelManager = FindObjectOfType<LevelManager>();
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            gameManager?.CollectItem(pointsValue);
            levelManager?.ItemCollected();
            Destroy(gameObject);
        }
    }
}
