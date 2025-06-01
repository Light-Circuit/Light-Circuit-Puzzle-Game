using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
     public int sceneIndex;
    public void OnButtonClick() {
        SceneManager.LoadScene($"Level{sceneIndex}");
    }

    public void SetIndex(int _index) {
        sceneIndex = _index;
        GetComponentInChildren<TextMeshProUGUI>().text = sceneIndex.ToString();
    }
}
