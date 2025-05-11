using System.Collections.Generic;
using UnityEngine;
using Player.Input;

public class Selector : MonoBehaviour
{
    public List<GameObject> Keys = new List<GameObject>();

    [SerializeField] private int columns = 4;
    [SerializeField] private int rows = 2; // İsteğe bağlı: otomatik de hesaplanabilir
    private int selectedIndex = 0;
    public GameObject selectedObject;
    private InputManager input;
    private AudioManager manager;

    void Awake()
    {
        input = FindAnyObjectByType<InputManager>();
        manager = FindAnyObjectByType<AudioManager>();
        
        // Eğer satır sayısı manuel değilse, otomatik hesapla
        if (rows <= 0)
        {
            rows = Mathf.CeilToInt((float)Keys.Count / columns);
        }
    }

    void Update()
    {
        HandleInput();
        UpdateSelection();
    }

    void HandleInput()
    {
        int currentRow = selectedIndex / columns;
        int currentCol = selectedIndex % columns;

        if (input.RightArrowPressed)
        {
            manager.PanelSwitc();
            currentCol = (currentCol + 1) % columns;
        }

        if (input.LeftArrowPressed)
        {
            manager.PanelSwitc();
            currentCol = (currentCol + columns - 1) % columns;
        }

        if (input.DownArrowPressed)
        {
            manager.PanelSwitc();
            currentRow = Mathf.Min(currentRow + 1, rows - 1);
        }

        if (input.UpArrowPressed)
        {
            manager.PanelSwitc();
            currentRow = Mathf.Max(currentRow - 1, 0);
        }

        int newIndex = currentRow * columns + currentCol;

        // Sınırları aşma kontrolü
        if (newIndex >= Keys.Count)
        {
            selectedIndex = Keys.Count - 1;
        }
        else
        {
            selectedIndex = newIndex;
        }
    }

    void UpdateSelection()
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            if (Keys[i] != null)
                Keys[i].GetComponent<SpriteRenderer>().color = Color.white;
        }

        if (selectedIndex >= 0 && selectedIndex < Keys.Count)
        {
            var selectedObj = Keys[selectedIndex];
            selectedObj.GetComponent<SpriteRenderer>().color = Color.yellow;
            selectedObject = selectedObj;
        }
    }
}
