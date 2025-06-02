using UnityEngine;
using UnityEngine.EventSystems;

public class UIButtonSound : MonoBehaviour, IPointerEnterHandler
{
    private AudioManager audioManager;

    void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (Input.mousePresent) // Sadece fare varsa tetikle
        {
            audioManager.ButtonSelectedSound();
        }
    }
}
