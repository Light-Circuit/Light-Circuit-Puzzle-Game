using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;


public class LevyerDetectorm : MonoBehaviour
{   
   public bool set;
   public void SetEnter(bool status)
   { 
     set=status;
   }
   public  bool GetEnter(){
    return set;
   }
}
