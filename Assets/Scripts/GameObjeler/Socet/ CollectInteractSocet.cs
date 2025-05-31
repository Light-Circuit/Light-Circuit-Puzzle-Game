using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectInteractSocet : BaseSocet
{
     
    public bool is_Collect;



    void Update()
    {
        SocetRule();
        SocetIsGate();
    }

    public override int Collect()
    {
        int id = 404;

        foreach (GateClass gate in logicGates)
        {
            if (gate.logic == null || gate.logic.gameObject == null || !gate.logic.gameObject.activeSelf)
            {
                continue;
            }

            id = gate.Id;
            gate.logic.gameObject.SetActive(false); 
            is_Collect = false;
            Debug.Log($"Collect işlemi tamamlandı, id: {id}");
            break;
        }
        if (id == 404)
        {
            Debug.LogWarning("Geçerli bir id bulunamadı.");
        }

        return id;
    }

    
    public override void SocetRule()
    {
        base.SocetRule();
    }
    public override bool GateAviable()
    {
        return base.GateAviable();
    }

   public override void AddLogic(int id)
    {
        base.AddLogic(id);
        is_Collect = true; 
        Debug.Log($"AddLogic ile sokete eklendi, id: {id}, is_Collect true yapıldı.");
    }

    public override void RemoveLogic()
    {
        base.RemoveLogic();
    }
    public override void SocetIsGate()
    {
        base.SocetIsGate();
    }
}
