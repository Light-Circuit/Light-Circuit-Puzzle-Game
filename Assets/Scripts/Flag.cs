using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Flag : MonoBehaviour
{
    int unlockedLevels;
    string numberOfLevelsUnlocked = "numberOfLevelsUnlocked";
    bool isFirstTime;
    int offset = 1;

    private void Start()
    {
        isFirstTime = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isFirstTime) {
            UnlockLevel();
        }
    }

    void UnlockLevel() {

        int checkIndex = SceneManager.GetActiveScene().buildIndex;

        unlockedLevels = PlayerPrefs.GetInt(numberOfLevelsUnlocked);

        if (unlockedLevels <= (checkIndex - offset) + 1) {
            unlockedLevels += 1;
            PlayerPrefs.SetInt(numberOfLevelsUnlocked, unlockedLevels);
            isFirstTime = false;
        }

     
    }
}
