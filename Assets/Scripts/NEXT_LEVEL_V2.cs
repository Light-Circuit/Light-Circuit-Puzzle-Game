using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NEXT_LEVEL_V2 : MonoBehaviour
{
    public GameObject finish;
    private bool hasPlayedWinSound = false; // Win sesinin tekrar oynamasýný engellemek için

    private void Update()
    {
        // Eðer Finish aktif olursa ve daha önce win sesi çalmadýysa
        if (finish.activeInHierarchy && !hasPlayedWinSound)
        {
            hasPlayedWinSound = true; // Tekrar etmesini engelle
            if (AudioManager.instance != null)
            {
                AudioManager.instance.PlaySFX(AudioManager.instance.Win); // Win sesi çal
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && finish.activeInHierarchy)
        {
            LoadNextLevel();
        }
    }

    private void LoadNextLevel()
    {
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
}
