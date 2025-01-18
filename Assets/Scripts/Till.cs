using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Till : MonoBehaviour
{
    public Sprite tillOpened;
    public Sprite tillClosed;
    public SpriteRenderer tillImage;
    public Setter set;
   
    void Update()
    {
        if (set.set)
        {
            tillImage.sprite = tillOpened;
            
        }
        else
        {
            tillImage.sprite = tillClosed;
            
        }
    }
}
