using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Input;
public class MenuLevel : MonoBehaviour
{
    public GameObject pauseMenu;
    InputManager inputManager;
    void Start()
    {
        inputManager=FindAnyObjectByType<InputManager>();
    }

    void Update()
    {
        
    }

}
