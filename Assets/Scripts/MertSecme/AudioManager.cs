using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance { get; private set; } 

     AudioSource m_AudioSource;
    [SerializeField] private AudioClip BackgroundSound;
    [SerializeField] private AudioClip Walksound;
    [SerializeField] private AudioClip UIbuttonSelected;
   [SerializeField] private AudioClip UIbuttonPressed;
  [SerializeField] private AudioClip collectSound;
    [SerializeField] private AudioClip addSound;
   [SerializeField] private AudioClip levyerSound;
    [SerializeField] private AudioClip PanelSwitch;
   [SerializeField] private AudioClip panelnoneSound;
    [SerializeField] public float sesValue=0.2f;

    
    void Awake()
    {
       
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        
        Instance = this;

        
        DontDestroyOnLoad(gameObject);

       
    }

    void Start()
{   m_AudioSource=GetComponent<AudioSource>();
    m_AudioSource.clip = BackgroundSound;
    m_AudioSource.loop = true; 
     
    m_AudioSource.Play(); 
}
    void Update()
    {
        m_AudioSource.volume = sesValue;
    }



    public void ButtonSelectedSound()
    {
      m_AudioSource.PlayOneShot(UIbuttonSelected, sesValue);
    }
     public void ButtonPressedSound()
    {
      m_AudioSource.PlayOneShot(UIbuttonPressed, sesValue);
    }
    public void WalkSound()
    {
      m_AudioSource.PlayOneShot(Walksound, sesValue);
    }
    public void AddSound()
    {
      m_AudioSource.PlayOneShot(addSound, sesValue);
    }
    public void CollectSound()
    {
      m_AudioSource.PlayOneShot(collectSound, sesValue);
    }
    public void LevyerSound()
    {
      m_AudioSource.PlayOneShot(levyerSound, sesValue);
    }
    public void PanelSwitc()
    {
        m_AudioSource.PlayOneShot(PanelSwitch, sesValue);
    }
     public void noneSound()
    {
        m_AudioSource.PlayOneShot(panelnoneSound, sesValue);
    }


}
    
   
  
    
  



