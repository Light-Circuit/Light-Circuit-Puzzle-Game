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

        public Vector2 move { get; private set; }
        public bool KeyE { get; private set; }
        public bool RightArrowPressed { get; private set; }
        public bool LeftArrowPressed { get; private set; }
        public bool UpArrowPressed { get; private set; }
        public bool DownArrowPressed { get; private set; }

        private bool keyEPressed;
        private bool rightPressed;
        private bool leftPressed;
        private bool upPressed;
        private bool downPressed;

        void Start()
        {
            currentInputMap = playerInput.currentActionMap;

            moveAction = currentInputMap.FindAction("PlayerMove");
            keyEAction = currentInputMap.FindAction("KeyE");
            upAction = currentInputMap.FindAction("Up");
            downAction = currentInputMap.FindAction("Down");
            leftAction = currentInputMap.FindAction("Left");
            rightAction = currentInputMap.FindAction("Right");

            moveAction.performed += OnMove;
            moveAction.canceled += OnMove;

            keyEAction.performed += ctx => keyEPressed = ctx.performed;
            upAction.performed += ctx => upPressed = ctx.performed;
            downAction.performed += ctx => downPressed = ctx.performed;
            leftAction.performed += ctx => leftPressed = ctx.performed;
            rightAction.performed += ctx => rightPressed = ctx.performed;

            keyEAction.Enable();
            upAction.Enable();
            downAction.Enable();
            leftAction.Enable();
            rightAction.Enable();
        }

        void Update()
        {
            HandleKeyE();
            HandleDirectionKeys();
        }

        private void HandleKeyE()
        {
            KeyE = keyEPressed;
            keyEPressed = false;
        }

        private void HandleDirectionKeys()
        {
            RightArrowPressed = rightPressed;
            LeftArrowPressed = leftPressed;
            UpArrowPressed = upPressed;
            DownArrowPressed = downPressed;

            // Reset the pressed states after handling them
            rightPressed = false;
            leftPressed = false;
            upPressed = false;
            downPressed = false;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            move = context.ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            moveAction.performed -= OnMove;
            moveAction.canceled -= OnMove;

            keyEAction.performed -= ctx => keyEPressed = ctx.performed;
            upAction.performed -= ctx => upPressed = ctx.performed;
            downAction.performed -= ctx => downPressed = ctx.performed;
            leftAction.performed -= ctx => leftPressed = ctx.performed;
            rightAction.performed -= ctx => rightPressed = ctx.performed;

            keyEAction.Disable();
            upAction.Disable();
            downAction.Disable();
            leftAction.Disable();
            rightAction.Disable();
        }
    }
}
