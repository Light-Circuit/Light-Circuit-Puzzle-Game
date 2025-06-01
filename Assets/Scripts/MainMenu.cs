using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    private AudioManager manager;

    public GameObject OptionsPanel;
    public GameObject MenuPanel;
    public SelectedUI selectedUI;
    public GameObject PauseButton;
    public GameObject PlayButton;

    [Header("Options Panelindeki İlk Seçilecek UI Objesi")]
    public GameObject firstOptionButton;

    void Start()
    {
        manager = FindAnyObjectByType<AudioManager>();

        if (firstOptionButton == null)
        {
            Debug.LogWarning("firstOptionButton atanmadı! Gamepad kontrolü olmayabilir.");
        }
    }

    public void PlayGame()
    {
        manager.ButtonSelectedSound();
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        manager.ButtonSelectedSound();
        Debug.Log("QUIT!");
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
