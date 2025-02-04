using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Mert.Input{
public class InputManager : MonoBehaviour
{
    [SerializeField] private PlayerInput playerInput;
    private InputActionMap currentInputMaps;
    private InputAction moveAction;
    public Vector2 move{get; private set;}

    void Start()
    {
        currentInputMaps=playerInput.currentActionMap;
        moveAction=currentInputMaps.FindAction("PlayerMove");
        moveAction.performed += OnMove;
       
        moveAction.canceled+=OnMove;

        
    }

   
    private void OnMove(InputAction.CallbackContext context)
    {
        move = context.ReadValue<Vector2>();
    }

   
}
}

