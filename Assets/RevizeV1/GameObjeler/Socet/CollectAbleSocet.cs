using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectAbleSocet : BaseSocet {

    public bool is_Collect=false;
   
   
   public override int Collect()
    {  
         int id = 404; 
        
        if (is_Collect) 
            return id;

        foreach (GateClass gate in logicGates)
        {
            if (gate.logic == null || gate.logic.gameObject == null || !gate.logic.gameObject.activeSelf)
            {
                continue; 
            }

            id = gate.Id; 
            break; 
        }

        base.Collect();
        is_Collect = true;
        Debug.Log($"colletableSocet değeri{id}");
        return id;
    }

}
