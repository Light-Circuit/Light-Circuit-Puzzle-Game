using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    
    public Till sonuc_kablo; 
    public GameObject finish; 

    private void Update()
    {
       
        if (sonuc_kablo.set.set)
        {
            finish.SetActive(true);
            Debug.Log("sonraki bölüme geç");

        }
        else
        {
            finish.SetActive(false);
            Debug.Log("sonraki bölüme geçme");
        }
    }
}
