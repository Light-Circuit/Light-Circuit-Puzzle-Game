using UnityEngine;
using Mert.Input;
using System.Security.Cryptography;

public class PanelSystem : MonoBehaviour
{
  InputManager input;
  public Selector keys;

    void Start()
    {
        input=FindAnyObjectByType<InputManager>();
    }
    public void PutLogic()
    {
        if(input.KeyE)
        {
          //e basttığında logic koyacak
        }
    }


}