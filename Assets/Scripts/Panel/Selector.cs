using System.Collections.Generic;
using UnityEngine;
using Player.Input;
public class Selector : MonoBehaviour
{   
    public List<GameObject> Keys = new List<GameObject>(); 
    private int selectedIndex = 0;
    public GameObject selectedObject;
    InputManager input;
    AudioManager manager;
    private const int columns = 4; 
    private const int rows = 2;

    void Awake()
    {
        input=FindAnyObjectByType<InputManager>();
        manager=FindAnyObjectByType<AudioManager>();
    }
    void Update()
    {
        HandleInput();
        UpdateSelection();
    }

    void HandleInput()
    {//InputManeger
        int currentRow = selectedIndex / columns;
        int currentCol = selectedIndex % columns;

        if (input.RightArrowPressed){
            manager.PanelSwitc();
            currentCol = (currentCol + 1) % columns;}

        if (input.LeftArrowPressed){
            manager.PanelSwitc();
            currentCol = (currentCol + columns - 1) % columns;}

        if (input.DownArrowPressed){
            manager.PanelSwitc();
            currentRow = Mathf.Min(currentRow + 1, rows - 1);}

        if (input.UpArrowPressed){
            manager.PanelSwitc();
            currentRow = Mathf.Max(currentRow - 1, 0);}

        selectedIndex = currentRow * columns + currentCol;
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
            selectedObject=selectedObj;
            
          
        }
    }
}
