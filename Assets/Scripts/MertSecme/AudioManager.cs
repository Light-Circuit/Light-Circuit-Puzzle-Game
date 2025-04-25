using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } 

    private AudioSource m_AudioSource;
    public AudioClip BackgroundSound;
    public AudioClip WalkSound;

    public float sesValue;

    
    void Awake()
    {
       
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        
        Instance = this;

        
        DontDestroyOnLoad(gameObject);

        m_AudioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
       
    }

    void Update()
    {
        
    }

   
    public void SetVolume(float volume)
    {
        m_AudioSource.volume = volume;
    }

    
  



}
