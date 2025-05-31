using Player.Input;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    InputManager Input;
    public GameObject pauseMenu;
    private bool isPaused = false;

    void Start()
    {
        Input = FindAnyObjectByType<InputManager>();
    }

    void Update()
    {
        if (Input.pauseKey)
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);
        Time.timeScale = isPaused ? 0f : 1f;
    }
}
