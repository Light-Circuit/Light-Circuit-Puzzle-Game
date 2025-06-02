using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Finish : MonoBehaviour {
    
    int unlockedLevels;
    string numberOfLevelsUnlocked = "numberOfLevelsUnlocked";
    bool isFirstTime;
    int offset = 1;
    public BaseSet set;
   public int soketnumberAdd;
    public int SoketSayisi;
    public TextMeshProUGUI SoketNumberText;


    void Start()
    {
        isFirstTime =true;
    }
    void Update()
    {
        TextWrite();
    }

    private void TextWrite()
    {
        SoketNumberText.text = $"{soketnumberAdd}/{SoketSayisi}";
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (set.GetSet() && SoketSayisi == soketnumberAdd)
        {
            Debug.Log("Devre Bitti...");
            if (other.gameObject.CompareTag("Player") && isFirstTime)
            {
                Debug.Log("Devre bitti İşlemleri yapıyorum");
                LoadNextLevel();
                UnlockLevel();

            }

        }
        else
        {
            Debug.Log("Devre bitmedi daha...");
        }
    }
    

    private void LoadNextLevel()
    {

        //yükleeniyor
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        print(currentSceneIndex);

        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            SceneManager.LoadScene(0);
        }
    }
      void UnlockLevel() {
          //level Acıyor
        int checkIndex = SceneManager.GetActiveScene().buildIndex;

        unlockedLevels = PlayerPrefs.GetInt(numberOfLevelsUnlocked);

        if (unlockedLevels <= (checkIndex - offset) + 1) {
            unlockedLevels += 1;
            PlayerPrefs.SetInt(numberOfLevelsUnlocked, unlockedLevels);
            isFirstTime = false;
        }

     
    }
}