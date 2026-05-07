using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField] private float moveSpeed = 5f;
    
    [Header("References")]
    private Rigidbody2D rb;
    private Vector2 moveDirection = Vector2.zero;
    private GameManager gameManager;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = FindObjectOfType<GameManager>();
    }
    
    private void Update()
    {
        // Only allow input if game is running
        if (!gameManager.IsGameRunning)
        {
            rb.velocity = Vector2.zero;
            return;
        }
        
        HandleInput();
    }
    
    private void FixedUpdate()
    {
        // Apply movement
        rb.velocity = moveDirection * moveSpeed;
    }
    
    private void HandleInput()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        
        moveDirection = new Vector2(horizontalInput, verticalInput).normalized;
    }
    
    public void TakeDamage()
    {
        // Called when hitting a hazard
        gameManager.LoseLife();
        AudioManager.Instance?.PlayHitSound();
        
        // Knockback effect
        rb.velocity = -moveDirection * 10f;
    }
    
    public void ResetPosition(Vector3 spawnPoint)
    {
        transform.position = spawnPoint;
        rb.velocity = Vector2.zero;
    }
}
