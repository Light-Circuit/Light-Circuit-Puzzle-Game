using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setter : MonoBehaviour
{
    [Header("Setterlar di�er devrelere,kablolara ve harici devrelere ba�lamak i�in")] 
    public Lever lever;
    public Devre devre;
    [Header("LEVER1 setter")]
    public bool lever_1;
    [Header("LEVER setter")]
    public bool lever_;
    [Header("Devre setter")]
    public bool devre_;

    public bool set;

    

    void Update()
    {
       
        if (lever_)
        {
            set = lever._set;
        }
        if (devre_)
        {
            set = devre.devreSetter;
        }
    }
}
