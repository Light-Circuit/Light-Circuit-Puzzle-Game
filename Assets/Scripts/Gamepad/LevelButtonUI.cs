using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class LevelButtonUI : MonoBehaviour
{
    [Header("UI Referansları")]
    public GameObject levelbutton;

    [Header("Ses Sistemi")]
    private AudioManager audioManager;

    private PlayerInput playerInput;
    private EventSystem eventSystem;

    private string currentControlScheme;
    private bool mouseMoved = false;
    private GameObject lastSelected;

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

        SelectButton(levelbutton); 
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
    }
    void Start()
    {
        audioManager.sesValue = PlayerPrefs.GetFloat("ses")/10;
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
                    SelectButton(levelbutton); 
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
                SelectButton(levelbutton);
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
