using UnityEngine;

public class LevyerDetectorm : MonoBehaviour
{
    public bool set;
    public bool use_lever = true; // Lever kullanılabilir mi?

    public void SetEnter(bool status)
    {
        if (!use_lever) return; // Kullanılamıyorsa değişiklik yapma
        set = status;
    }

    public bool GetEnter()
    {
        return set;
    }
}
