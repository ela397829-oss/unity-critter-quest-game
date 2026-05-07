using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; }
    
    [Header("Audio Clips")]
    [SerializeField] private AudioClip collectSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip backgroundMusic;
    
    private AudioSource audioSource;
    private AudioSource musicSource;
    
    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
    
    private void Start()
    {
        // Create audio sources
        audioSource = gameObject.AddComponent<AudioSource>();
        musicSource = gameObject.AddComponent<AudioSource>();
        
        // Setup music source
        musicSource.clip = backgroundMusic;
        musicSource.loop = true;
        musicSource.volume = 0.3f;
        
        if (backgroundMusic)
            musicSource.Play();
    }
    
    public void PlayCollectSound()
    {
        if (collectSound && audioSource)
            audioSource.PlayOneShot(collectSound);
    }
    
    public void PlayHitSound()
    {
        if (hitSound && audioSource)
            audioSource.PlayOneShot(hitSound);
    }
    
    public void StopMusic()
    {
        if (musicSource)
            musicSource.Stop();
    }
}
