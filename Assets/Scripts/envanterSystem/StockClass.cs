using System;

using UnityEngine;
[Serializable]
public class StockClass  
{
 

 
public int Id;
public string Name;

  
  
    [SerializeField]
    private int _stock; 

    public int stock
    {
        get { return _stock; }
        set { _stock = Mathf.Max(0, value); }
    }
}