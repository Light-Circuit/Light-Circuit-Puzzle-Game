using System.Collections.Generic;
using UnityEngine;

public class Selector : MonoBehaviour
{   
    public List<GameObject> Keys = new List<GameObject>(); 
    private int selectedIndex = 0;
    public GameObject selectedObject;

    private const int columns = 4; 
    private const int rows = 2;    

    void Update()
    {
        HandleInput();
        UpdateSelection();
    }

    void HandleInput()
    {//InputManeger
        int currentRow = selectedIndex / columns;
        int currentCol = selectedIndex % columns;

        if (Input.GetKeyDown(KeyCode.RightArrow))
            currentCol = (currentCol + 1) % columns;

        if (Input.GetKeyDown(KeyCode.LeftArrow))
            currentCol = (currentCol + columns - 1) % columns;

        if (Input.GetKeyDown(KeyCode.DownArrow))
            currentRow = Mathf.Min(currentRow + 1, rows - 1);

        if (Input.GetKeyDown(KeyCode.UpArrow))
            currentRow = Mathf.Max(currentRow - 1, 0);

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
