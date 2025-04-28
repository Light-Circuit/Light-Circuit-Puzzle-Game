using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cable : MonoBehaviour
{
    public Sprite CableOpened;
    public Sprite CableClosed;
    private SpriteRenderer CableImage;
    public BaseSet set;
    void Start()
    {
        CableImage=GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        if (set.GetSet())
        {
            CableImage.sprite = CableOpened;
            
        }
        else
        {
            CableImage.sprite = CableClosed;
            
        }
    }
}
