using System;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;



public class OptionsManager : MonoBehaviour{

    private float volume = 5f;

    public TextMeshProUGUI Volumenumber;
    
    public AudioManager audioManager;

 void Start()
    {
        audioManager = FindAnyObjectByType<AudioManager>();
        
    }

void Update()
    {
        volume = Math.Clamp(volume,0f,10f);
         Volumenumber.text = volume.ToString();
         audioManager.sesValue=volume/10;
    }
    public void AnaMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void IncreaseAudio()
    {
     volume++;
     
    }
    public void DecreaseAudio()
    {
     volume--;
    }
}