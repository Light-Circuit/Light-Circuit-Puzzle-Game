using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        private InputActionMap currentInputMap;

        private InputAction moveAction;
        private InputAction keyEAction;
        private InputAction upAction;
        private InputAction downAction;
        private InputAction leftAction;
        private InputAction rightAction;
        private InputAction pauseAction;

        public Vector2 move { get; private set; }
        public bool KeyE { get; private set; }
        public bool pauseKey { get; private set; }
        public bool RightArrowPressed { get; private set; }
        public bool LeftArrowPressed { get; private set; }
        public bool UpArrowPressed { get; private set; }
        public bool DownArrowPressed { get; private set; }

        private bool keyEPressed;
        private bool rightPressed;
        private bool leftPressed;
        private bool upPressed;
        private bool downPressed;
        private bool pausePressed;

        void Start()
        {
            if (playerInput == null)
            {
                playerInput = GetComponent<PlayerInput>();
            }

            currentInputMap = playerInput.currentActionMap;
            UpdateActionReferences();
        }

        void Update()
        {
            HandleKeyE();
            HandleKeyP();
            HandleDirectionKeys();
        }

        private void HandleKeyE()
        {
            KeyE = keyEPressed;
            keyEPressed = false;
        }

        private void HandleKeyP()
        {
            pauseKey = pausePressed;
            pausePressed = false;
        }

        private void HandleDirectionKeys()
        {
            RightArrowPressed = rightPressed;
            LeftArrowPressed = leftPressed;
            UpArrowPressed = upPressed;
            DownArrowPressed = downPressed;

            rightPressed = false;
            leftPressed = false;
            upPressed = false;
            downPressed = false;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            move = context.ReadValue<Vector2>();
        }

        public void SwitchActionMap(string newMap)
        {
            if (playerInput.currentActionMap.name == newMap) return;

            playerInput.SwitchCurrentActionMap(newMap);
            currentInputMap = playerInput.currentActionMap;

            UpdateActionReferences();
        }

        private void UpdateActionReferences()
        {
            // Önce eski bağlantıları kaldır
            if (moveAction != null)
            {
                moveAction.performed -= OnMove;
                moveAction.canceled -= OnMove;
            }

            // Yeni Action Map'e göre aksiyonları bul
            moveAction = currentInputMap.FindAction("PlayerMove");
            keyEAction = currentInputMap.FindAction("KeyE");
            upAction = currentInputMap.FindAction("Up");
            downAction = currentInputMap.FindAction("Down");
            leftAction = currentInputMap.FindAction("Left");
            rightAction = currentInputMap.FindAction("Right");
            pauseAction = currentInputMap.FindAction("Pause");

            // Aksiyonları bağla ve enable et
            if (moveAction != null)
            {
                moveAction.performed += OnMove;
                moveAction.canceled += OnMove;
                moveAction.Enable();
            }

            if (keyEAction != null)
            {
                keyEAction.performed += ctx => keyEPressed = ctx.performed;
                keyEAction.Enable();
            }

            if (upAction != null)
            {
                upAction.performed += ctx => upPressed = ctx.performed;
                upAction.Enable();
            }

            if (downAction != null)
            {
                downAction.performed += ctx => downPressed = ctx.performed;
                downAction.Enable();
            }

            if (leftAction != null)
            {
                leftAction.performed += ctx => leftPressed = ctx.performed;
                leftAction.Enable();
            }

            if (rightAction != null)
            {
                rightAction.performed += ctx => rightPressed = ctx.performed;
                rightAction.Enable();
            }

            if (pauseAction != null)
            {
                pauseAction.performed += ctx => pausePressed = ctx.performed;
                pauseAction.Enable();
            }
        }

        private void OnDisable()
        {
            if (moveAction != null)
            {
                moveAction.performed -= OnMove;
                moveAction.canceled -= OnMove;
            }

            if (keyEAction != null) keyEAction.Disable();
            if (upAction != null) upAction.Disable();
            if (downAction != null) downAction.Disable();
            if (leftAction != null) leftAction.Disable();
            if (rightAction != null) rightAction.Disable();
            if (pauseAction != null) pauseAction.Disable();
        }
    }
}
