using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyGate : MonoBehaviour
{
    public KeyClass keyBinding;
    public TextMesh textStok;
    public bool isDeactive;
    private Material material;

    void Start()
    {
        textStok = transform.GetChild(0).GetComponent<TextMesh>();

       
        material = GetComponent<Renderer>().material;
    }

    public void Sondur(float alpha)
    {
        if (material != null)
        {
            Color c = material.color;
            material.color = new Color(c.r, c.g, c.b, alpha); 
        }
    }
}

   

    

