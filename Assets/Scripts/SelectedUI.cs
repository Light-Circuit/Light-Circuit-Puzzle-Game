using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class SelectedUI : MonoBehaviour
{
    private EventSystem eventSystem;
    private AudioManager audioManager;
    private PlayerInput playerInput;

    public GameObject SelectedButton;
    private GameObject lastSelectedButton;

    private string lastControlScheme; 
    private bool mouseMoved = false;

    void Start()
    {
        eventSystem = GetComponent<EventSystem>();
        playerInput = FindAnyObjectByType<PlayerInput>();
        audioManager = FindAnyObjectByType<AudioManager>();

        lastSelectedButton = null;
        lastControlScheme = playerInput.currentControlScheme;

        playerInput.onControlsChanged += OnControlsChanged;
    }

    void Update()
    {
        SelectedButton = eventSystem.currentSelectedGameObject;
        
        DetectMouseMovement();
        SwitchButton();
    }

    void DetectMouseMovement()
    {
        // Eğer mouse hareket ederse veya tıklanırsa, mouseMoved = true yap
        if (Mouse.current.delta.ReadValue() != Vector2.zero || Mouse.current.leftButton.wasPressedThisFrame)
        {
            mouseMoved = true;
        }
    }

    void SwitchButton()
    {
        if (SelectedButton != lastSelectedButton)
        {
            if (!mouseMoved) // Sadece mouse ile değilse
            {
                if (SelectedButton != null)
                {
                    audioManager.ButtonSelectedSound();
                }
            }

            lastSelectedButton = SelectedButton;
        }
    }

    void OnControlsChanged(PlayerInput input)
    {
        lastControlScheme = input.currentControlScheme;
        
        // Eğer kontrol Gamepad ise mouse hareketini sıfırla
        if (lastControlScheme == "Gamepad")
        {
            mouseMoved = false;
        }
        else if (lastControlScheme == "Keyboard&Mouse")
        {
            // Klavye kullanıyor olabilir ama mouse hareket etmişse mouseMoved zaten true olur
            // Yani burada ekstra bir şey yapmaya gerek yok
        }
    }
}
