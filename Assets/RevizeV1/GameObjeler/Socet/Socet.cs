using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Socet : BaseSet, IBaseSocet
{
    public GateClass[] logicGates; 
    public BaseSet[] set;
    public bool result;

    public override bool GetSet()
    {
        return result;
    }

    void Update()
    {
        SocetRule();
    }

    private void SocetRule()
    {
        foreach (GateClass gate in logicGates)
        {
            if (gate.logic.gameObject.activeSelf)
            {
                bool input1 = set[0].GetSet();
                bool input2 = set[1].GetSet();
                bool gateResult = gate.logic.Gate(input1, input2);
                result = gateResult;
            }
        }
    }

  
    public void AddLogic(int id)
    {
        int objId = id;

        foreach (GateClass gate in logicGates)
        {
            gate.logic.gameObject.SetActive(false);
        }
        
        foreach (GateClass gate in logicGates)
        {
            if (gate.logic != null) 
            {
                if (gate.Id == objId)
                {
                    if (gate.logic != null && gate.logic.gameObject != null)
                    {
                        gate.logic.gameObject.SetActive(true);
                        Debug.Log("Aktif edilen objenin ismi: " + gate.logic.name);
                        break; 
                    }
                }
            }
            else
            {
                Debug.Log("Gate logic null!"); 
            }
        } 
    }

    public void RemoveLogic()
    {
        foreach (GateClass gate in logicGates)
        {
            gate.logic.gameObject.SetActive(false);
        }
    }
}
