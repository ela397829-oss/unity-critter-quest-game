using UnityEngine;

public class Hazard : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private float moveDistance = 5f;
    [SerializeField] private bool isMoving = true;
    
    private Vector3 startPosition;
    private Vector3 moveDirection = Vector3.right;
    private float distanceTraveled = 0f;
    private PlayerController player;
    
    private void Start()
    {
        startPosition = transform.position;
        player = FindObjectOfType<PlayerController>();
    }
    
    private void Update()
    {
        if (isMoving)
        {
            MoveHazard();
        }
    }
    
    private void MoveHazard()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
        distanceTraveled += speed * Time.deltaTime;
        
        if (distanceTraveled >= moveDistance)
        {
            moveDirection *= -1;
            distanceTraveled = 0f;
        }
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player?.TakeDamage();
        }
    }
}
