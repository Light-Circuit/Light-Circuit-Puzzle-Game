using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [Header("Audio Sources")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource SFXSource;

    [Header("Audio Clips")]
    public AudioClip background;
    public AudioClip backgroundMenu;
    public AudioClip Win;
    public AudioClip WalkSound;
    public AudioClip button;
    public AudioClip circuitConnectSound; // Devre ekleme sesi

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayBackgroundMusic();
    }

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        PlayBackgroundMusic();
    }

    private void PlayBackgroundMusic()
    {
        string sceneName = SceneManager.GetActiveScene().name;

        if (sceneName == "MainMenu" || sceneName == "levelSelection")
        {
            if (musicSource.clip != backgroundMenu)
            {
                musicSource.clip = backgroundMenu;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
        else
        {
            if (musicSource.clip != background)
            {
                musicSource.clip = background;
                musicSource.loop = true;
                musicSource.Play();
            }
        }
    }

    public void PlayButtonSound()
    {
        if (button != null)
        {
            SFXSource.PlayOneShot(button);
        }
    }

    public void PlayCircuitConnectSound()
    {
        if (circuitConnectSound != null)
        {
            SFXSource.PlayOneShot(circuitConnectSound);
        }
    }

    public void PlaySFX(AudioClip clip)
    {
        if (clip != null)
        {
            SFXSource.PlayOneShot(clip);
        }
    }
}
