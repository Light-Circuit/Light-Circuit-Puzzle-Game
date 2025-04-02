using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Setter : MonoBehaviour
{
    [Header("Setterlar diğer devrelere, kablolara ve harici devrelere bağlamak için")]
    public Lever lever;
    public Devre devre;

    [Header("LEVER1 setter")]
    public bool lever_1;

    [Header("LEVER setter")]
    public bool lever_;

    [Header("Devre setter")]
    public bool devre_;

    public bool set;

    private bool lastState = false;
    private string setSource = ""; // "lever", "devre", "lever1" gibi

    void Update()
    {
        // 🔍 Hangi kaynaktan "set" geldiğini belirle
        if (lever_)
        {
            set = lever._set;
            setSource = "lever";
        }
        else if (lever_1)
        {
            set = lever._set;
            setSource = "lever1";
        }
        else if (devre_)
        {
            set = devre.devreSetter;
            setSource = "devre";
        }

        // ✅ Sadece LEVER'dan gelen değişikliklerde ses çal
        if (set != lastState)
        {
            lastState = set;

            if ((setSource == "lever" || setSource == "lever1") && AudioManager.instance != null)
            {
                AudioManager.instance.PlayButtonSound();
            }
        }
    }
}
