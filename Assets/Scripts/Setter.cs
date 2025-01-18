using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setter : MonoBehaviour
{
    [Header("Setterlar diðer devrelere,kablolara ve harici devrelere baðlamak için")] 
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
