using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
    public int sceneIndex;

   
    public bool isUnlocked = false;

    public void OnButtonClick()
    {
        if (isUnlocked)
        {
            SceneManager.LoadScene($"Level{sceneIndex}");
        }
        else
        {
            Debug.Log($"Level {sceneIndex} kilitli.");
           
        }
    }

    public void SetIndex(int _index)
    {
        sceneIndex = _index;
        GetComponentInChildren<TextMeshProUGUI>().text = sceneIndex.ToString();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
