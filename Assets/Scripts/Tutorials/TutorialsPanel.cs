using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TutorialsPanel : MonoBehaviour
{
    public TextMeshProUGUI description;
    public TextMeshProUGUI Name;
    public Image resim;

    private CharacterInteract CharacterInteract;
    GameObjectsList gameObjectsList;
    void Start()
    {
       
        TextAsset JsonFile=Resources.Load<TextAsset>("GameObjects");
        gameObjectsList = JsonUtility.FromJson<GameObjectsList>(JsonFile.text);
        CharacterInteract=FindAnyObjectByType<CharacterInteract>();
    
    }

   
    void Update()
    {
        foreach (var t in gameObjectsList.GameObjects)
        {
            if(CharacterInteract._tutorials.defination.id==t.id)
            {
               
                    description.text=t.description.ToString();
                    Name.text=t.name.ToString();
                    resim.sprite=Resources.Load<Sprite>($"{t.id}");
                
            }
        }
    }
}
