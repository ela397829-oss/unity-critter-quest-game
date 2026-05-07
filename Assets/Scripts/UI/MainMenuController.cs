using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button startButton;
    [SerializeField] private Button quitButton;
    
    private void Start()
    {
        if (startButton)
            startButton.onClick.AddListener(() => SceneManager.LoadScene("Level1"));
        
        if (quitButton)
            quitButton.onClick.AddListener(() => Application.Quit());
    }
}
