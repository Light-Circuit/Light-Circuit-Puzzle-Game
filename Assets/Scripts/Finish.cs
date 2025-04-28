using UnityEngine;
using UnityEngine.SceneManagement;
public class Finish : MonoBehaviour {
    
      int unlockedLevels;
    string numberOfLevelsUnlocked = "numberOfLevelsUnlocked";
    bool isFirstTime;
    int offset = 1;
    public BaseSet set;


    void Start()
    {
        isFirstTime=true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(set.GetSet())
        {
           Debug.Log("Devre Bitti...");
            if (other.gameObject.CompareTag("Player") &&  isFirstTime)
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