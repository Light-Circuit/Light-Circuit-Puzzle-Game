using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnvanterSystem : MonoBehaviour
{

public StockClass[] stocks;

   

    public void AddStock(int id)
    {
     
          foreach (StockClass item in stocks)
          {
            if(item.Id==id)
            {
                item.stock++;
            }
          }
      
           
    }
   
   public bool HasStock(int id)
{
    foreach (StockClass stock in stocks)
    {
        if (stock.Id == id)
        {
            return stock.stock > 0;
        }
    }
    return false;
}

public void DecStock(int id)
{
    foreach (StockClass stock in stocks)
    {
        if (stock.Id == id)
        {
            stock.stock = Mathf.Max(0, stock.stock - 1);
        }
    }
}

}
