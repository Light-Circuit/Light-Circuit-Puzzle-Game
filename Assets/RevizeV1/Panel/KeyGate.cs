using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : MonoBehaviour
{
    
    public KeyClass keyBinding;
   public TextMesh textStok;
   public bool isDeactive;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        textStok=transform.GetChild(0).GetComponent<TextMesh>();
        spriteRenderer=GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        Sondur();
    }
    public void Sondur()
    {
       if (isDeactive) 
       {
           spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 0.5f);
           
       }   
       else
       {
           spriteRenderer.color = new Color(spriteRenderer.color.r, spriteRenderer.color.g, spriteRenderer.color.b, 1f);
           
       }
    }
    

    
}
