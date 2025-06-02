using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SelectedUI : MonoBehaviour
{
    [Header("UI Referansları")]
    public GameObject mainMenu;
    public GameObject optionsMenu;
    public GameObject playButton;
    public GameObject backButton;

    [Header("Ses Sistemi")]
    public AudioManager audioManager;

    private PlayerInput playerInput;
    private EventSystem eventSystem;

    private string currentControlScheme;
    private bool mouseMoved = false;
    private GameObject lastSelected;

    private bool previousOptionsActive;

    void Awake()
    {
        eventSystem = EventSystem.current;
        playerInput = FindAnyObjectByType<PlayerInput>();

        if (audioManager == null)
        {
            audioManager = FindAnyObjectByType<AudioManager>();
        }

        if (playerInput != null)
        {
            currentControlScheme = playerInput.currentControlScheme;
            playerInput.onControlsChanged += OnControlsChanged;
        }

        SelectButton(playButton); 
    }

    void Update()
    {
        DetectMouseMovement();

        GameObject current = eventSystem.currentSelectedGameObject;

        if (current != null && current != lastSelected && !mouseMoved)
        {
            if (audioManager != null)
            {
                audioManager.ButtonSelectedSound();
            }

            lastSelected = current;
        }

      
        if (optionsMenu.activeSelf)
        {
            if (current == null || !current.activeInHierarchy)
            {
                SelectButton(backButton);
            }
        }
      
        else if (mainMenu.activeSelf && previousOptionsActive)
        {
            SelectButton(playButton);
        }

        previousOptionsActive = optionsMenu.activeSelf;
    }

    void DetectMouseMovement()
    {
        if (Mouse.current != null)
        {
            if (Mouse.current.delta.ReadValue() != Vector2.zero || Mouse.current.leftButton.wasPressedThisFrame)
            {
                if (currentControlScheme != "Keyboard&Mouse")
                {
                    currentControlScheme = "Keyboard&Mouse";
                    SelectButton(playButton); 
                }

                mouseMoved = true;
            }
        }
    }

    void OnControlsChanged(PlayerInput input)
    {
        string newScheme = input.currentControlScheme;

        if (newScheme != currentControlScheme)
        {
            currentControlScheme = newScheme;

            if (currentControlScheme == "Gamepad")
            {
                mouseMoved = false;

                if (optionsMenu.activeSelf)
                {
                    SelectButton(backButton);
                }
                else if (mainMenu.activeSelf)
                {
                    SelectButton(playButton);
                }
            }
        }
    }

    void SelectButton(GameObject target)
    {
        if (target == null || !target.activeInHierarchy) return;

        eventSystem.SetSelectedGameObject(null);
        eventSystem.SetSelectedGameObject(target);
        lastSelected = target;
    }
}
