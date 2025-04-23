using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Mert.Input
{
    public class InputManager : MonoBehaviour
    {
        [SerializeField] private PlayerInput playerInput;
        private InputActionMap currentInputMaps;

        private InputAction moveAction;
        private InputAction keyEaction;
        private InputAction keyOneAction;
        private InputAction keyTwoAction;
        private InputAction keyThreeAction;
        private InputAction keyCancelAction;

        public Vector2 move { get; private set; }
        public bool KeyE { get; private set; }
        public bool KeyOne { get; private set; }
        public bool keyTwo { get; private set; }
        public bool keyThree { get; private set; }
        public bool keyCancel { get; private set; }

        private bool keyEPressed;
        private bool keyOnePressed;
        private bool keyTwoPressed;
        private bool keyThreePressed;
        private bool keyCancelPressed;

        void Start()
        {
            currentInputMaps = playerInput.currentActionMap;

            moveAction = currentInputMaps.FindAction("PlayerMove");
            keyEaction = currentInputMaps.FindAction("KeyE");
            keyOneAction = currentInputMaps.FindAction("KeyX");
            keyTwoAction = currentInputMaps.FindAction("Key2");
            keyThreeAction = currentInputMaps.FindAction("Key3");
            keyCancelAction = currentInputMaps.FindAction("Cancel");

            moveAction.performed += OnMove;
            moveAction.canceled += OnMove;
            // moveAction.Enable();

            keyEaction.performed += ctx => keyEPressed = ctx.performed;
            keyEaction.Enable();

            keyOneAction.performed += ctx => keyOnePressed = ctx.performed;
            keyOneAction.Enable();

            keyTwoAction.performed += ctx => keyTwoPressed = ctx.performed;
            keyTwoAction.Enable();

            keyThreeAction.performed += ctx => keyThreePressed = ctx.performed;
            keyThreeAction.Enable();

            keyCancelAction.performed += ctx => keyCancelPressed = ctx.performed;
            keyCancelAction.Enable();
        }

        void Update()
        {
            HandleKeyE();
            HandleKeyOne();
            HandleKeyTwo();
            HandleKeyThree();
            HandleKeyCancel();
        }

        private void HandleKeyE()
        {
            KeyE = keyEPressed;
            keyEPressed = false;  
        }

        private void HandleKeyOne()
        {
            KeyOne = keyOnePressed;
            keyOnePressed = false;
        }

        private void HandleKeyTwo()
        {
            keyTwo = keyTwoPressed;
            keyTwoPressed = false;
        }

        private void HandleKeyThree()
        {
            keyThree = keyThreePressed;
            keyThreePressed = false;
        }

        private void HandleKeyCancel()
        {
            keyCancel = keyCancelPressed;
            keyCancelPressed = false;
        }

        private void OnMove(InputAction.CallbackContext context)
        {
            move = context.ReadValue<Vector2>();
        }

        private void OnDisable()
        {
            moveAction.performed -= OnMove;
            moveAction.canceled -= OnMove;

            keyEaction.performed -= ctx => keyEPressed = ctx.performed;
            keyOneAction.performed -= ctx => keyOnePressed = ctx.performed;
            keyTwoAction.performed -= ctx => keyTwoPressed = ctx.performed;
            keyThreeAction.performed -= ctx => keyThreePressed = ctx.performed;
            keyCancelAction.performed -= ctx => keyCancelPressed = ctx.performed;
        }

       
    }
}
