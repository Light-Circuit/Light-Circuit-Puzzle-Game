using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class EnvanterSystem : MonoBehaviour
{

public StockClass[] stocks;
public KeyGate[] keys;
Material material;


    void Update()
    {
      KeysStockText();  
     Sondur();
    }

   public void Sondur()
{
    foreach (var keytext in keys)
    {
        if (keytext.textStok != null)
        {
            foreach (var stocktext in stocks)
            {
                if (stocktext.Id == keytext.keyBinding.Id)
                {
                    // Stock 0 ise alpha = 0.5, değilse alpha = 1
                    float alpha = stocktext.stock == 0 ? 0.5f : 1f;
                    keytext.Sondur(alpha); // Her KeyGate objesinin alpha değerini güncelle
                    break;
                }
            }
        }
    }
}



    public void KeysStockText()
    {
       
       foreach (var keytext in keys)
        { 
            
            if (keytext.textStok != null)
            {
                foreach (var stocktext in stocks) 
                {
                    if(stocktext.Id == keytext.keyBinding.Id)
                    {
                        keytext.textStok.text=stocktext.stock.ToString();
                    }
                }     
            }
        }

    }

    public void AddStock(int id)
{
    foreach (StockClass item in stocks)
    {
        if (item.Id == id)
        {
            item.stock = Mathf.Max(0, item.stock + 1); 
        }
    }
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

   

}
