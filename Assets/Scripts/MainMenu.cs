using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    AudioManager manager;
    public GameObject OptionsPanel;
    public GameObject MenuPanel;
    void Start()
    {
      manager=FindAnyObjectByType<AudioManager>();  
    }
    public void PlayGame()
    {
        manager.ButtonSelectedSound();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void QuitGame()
    {
        manager.ButtonSelectedSound();
        Debug.Log("QU�T!");
        Application.Quit();
    }
    public void OpenOptions()
    {
        manager.ButtonSelectedSound();
        OptionsPanel.SetActive(true);
        MenuPanel.SetActive(false);  
    }
     public void CloseOptions()
    {
        manager.ButtonSelectedSound();
        OptionsPanel.SetActive(false);
        MenuPanel.SetActive(true);  
    }

}
