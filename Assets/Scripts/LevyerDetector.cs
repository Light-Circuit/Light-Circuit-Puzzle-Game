using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class LevyerDetector : MonoBehaviour
{
    private bool canInteract = false;
    public GameObject x;
    public Lever lever;
    
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player"))
        {
            canInteract = true;
            x.SetActive(true);

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canInteract = false;
            x.SetActive(false);

        }
    }
   

    // Update is called once per frame
    void Update()
    {
       
        if (canInteract && Input.GetButtonDown("Fire2"))
        {
            if (!lever._set)
            {
                lever._set = true;
                Debug.Log("Fire1 button pressed, aPressed is now true");
            }
            else
            {
                lever._set = false;
                Debug.Log("Fire1 button pressed again, aPressed is now false");
            }
        }
       
    }
}
