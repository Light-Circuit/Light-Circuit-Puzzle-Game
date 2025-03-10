using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setter : MonoBehaviour
{
    [Header("Setterlar diğer devrelere,kablolara ve harici devrelere bağlamak için")]
    public Lever lever;
    public Devre devre;
    [Header("LEVER1 setter")]
    public bool lever_1;
    [Header("LEVER setter")]
    public bool lever_;
    [Header("Devre setter")]
    public bool devre_;

    public bool set;

    private bool lastState = false; // Önceki durumu saklar

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

        // 🔹 Eğer buton değiştiyse, buton sesi çal
        if (set != lastState)
        {
            lastState = set; // Yeni durumu kaydet

            // 🔹 Buton sesi çal (sadece AudioManager'daki buton sesi)
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlayButtonSound();
            }
        }
    }
}
