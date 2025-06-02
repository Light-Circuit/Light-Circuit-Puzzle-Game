using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectorButtonSound : MonoBehaviour
{
   AudioManager manager;
    void Start()
    {
        manager=FindAnyObjectByType<AudioManager>();
    }

   
   public void SoundClick(){
    manager.ButtonPressedSound();
   }
}
