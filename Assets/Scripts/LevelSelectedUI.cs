using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Player.Input;

public class LevelSelectedUI : MonoBehaviour
{
    public List<Button> Keys = new List<Button>();

    private int selectedIndex = 0;
    public Button selectedObject;

    private InputManager input;
    private AudioManager manager;

    private Color normalColor = Color.white;
    private Color selectedColor = Color.yellow;

    // Elle yön eşleşmeleri
    private Dictionary<int, int> upMap = new();
    private Dictionary<int, int> downMap = new();
    private Dictionary<int, int> leftMap = new();
    private Dictionary<int, int> rightMap = new();

    void Awake()
    {
        input = FindAnyObjectByType<InputManager>();
        manager = FindAnyObjectByType<AudioManager>();

        // Otomatik doldurmak istersen
        // Keys = new List<Button>(GetComponentsInChildren<Button>());

        // Yön eşleştirmeleri (sıralamayı inspector'da buna göre yapmalısın!)
        // 0 = üstteki buton, 1 = sol alttaki, 2 = sağ alttaki
        downMap[0] = 1;
        upMap[1] = 0;
        upMap[2] = 0;
        rightMap[1] = 2;
        leftMap[2] = 1;

        UpdateSelection();
    }

    void Update()
    {
        HandleInput();
        UpdateSelection();
    }

    void HandleInput()
    {
        int newIndex = selectedIndex;

        if (input.DownArrowPressed && downMap.ContainsKey(selectedIndex))
        {
            manager.PanelSwitc();
            newIndex = downMap[selectedIndex];
        }
        else if (input.UpArrowPressed && upMap.ContainsKey(selectedIndex))
        {
            manager.PanelSwitc();
            newIndex = upMap[selectedIndex];
        }
        else if (input.RightArrowPressed && rightMap.ContainsKey(selectedIndex))
        {
            manager.PanelSwitc();
            newIndex = rightMap[selectedIndex];
        }
        else if (input.LeftArrowPressed && leftMap.ContainsKey(selectedIndex))
        {
            manager.PanelSwitc();
            newIndex = leftMap[selectedIndex];
        }

        if (newIndex >= 0 && newIndex < Keys.Count)
        {
            selectedIndex = newIndex;
        }
    }

    void UpdateSelection()
    {
        for (int i = 0; i < Keys.Count; i++)
        {
            if (Keys[i] != null)
            {
                ColorBlock cb = Keys[i].colors;
                cb.normalColor = normalColor;
                Keys[i].colors = cb;
                Keys[i].transform.localScale = Vector3.one;
            }
        }

        if (selectedIndex >= 0 && selectedIndex < Keys.Count && Keys[selectedIndex] != null)
        {
            selectedObject = Keys[selectedIndex];
            ColorBlock selectedCB = selectedObject.colors;
            selectedCB.normalColor = selectedColor;
            selectedObject.colors = selectedCB;
            selectedObject.transform.localScale = Vector3.one * 1.1f;
        }
    }
}
