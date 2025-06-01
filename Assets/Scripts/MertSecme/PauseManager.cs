using Player;
using Player.Input;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private InputManager input;
    public GameObject pauseMenu;
    private bool isPaused = false;

    void Start()
    {
        input = FindAnyObjectByType<InputManager>();
    }

    void Update()
    {
        if (input.pauseKey)
        {
            TogglePause();
        }
    }

    void TogglePause()
    {
        isPaused = !isPaused;
        pauseMenu.SetActive(isPaused);

        if (isPaused)
        {
            input.SwitchActionMap("UI");
        }
        else
        {
            input.SwitchActionMap("Player");
        }

        // Time.timeScale = isPaused ? 0f : 1f;
    }
}
