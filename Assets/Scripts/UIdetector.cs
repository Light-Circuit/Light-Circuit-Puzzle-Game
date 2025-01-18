using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIdetector : MonoBehaviour
{
    public GameObject _panel;
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player")) {
            _panel.SetActive(true); 
        }
       
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
      
        if (collision.CompareTag("Player")) {
            _panel.SetActive(false); 
        }
       
    }

}
