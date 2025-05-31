using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class BaseSocet : BaseSet, IBaseSocet
{
    public GateClass[] logicGates;
    public BaseSet[] set;
    public bool result;
    private Finish finish;
    private bool socetİsnull;
    private bool previousSocketState = false;
    public AudioManager audioManager;

    void Start()
    {
        finish = FindAnyObjectByType<Finish>();
        audioManager = FindAnyObjectByType<AudioManager>();
    }
   
    public override bool GetSet()
    {
        return result;
    }


    public virtual void SocetRule()
    {
        if (set == null || set.Length < 2 || set[0] == null || set[1] == null)
        {
            result = false;
            return;
        }

        bool input1 = set[0].GetSet();
        bool input2 = set[1].GetSet();

        bool aktifKapı = false;

        foreach (GateClass gate in logicGates)
        {
            if (gate.logic == null || gate.logic.gameObject == null || !gate.logic.gameObject.activeSelf)
            {
                continue;
            }

            aktifKapı = true;

            if (gate.logic is Buffer || gate.logic is Not)
            {
                result = gate.logic.Gate(input1);
                
            }
            else
            {
                result = gate.logic.Gate(input1, input2);

            }

            break;
        }

        if (!aktifKapı)
        {
            result = false;

        }
       
    }


    public virtual void AddLogic(int id)
    {
        int objId = id;

        RemoveLogic();

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

    public virtual void RemoveLogic()
    {
        foreach (GateClass gate in logicGates)
        {
            gate.logic.gameObject.SetActive(false);
        }
    }


    public virtual int Collect()
    {
        RemoveLogic();
        return 404;
    }

    public virtual bool GateAviable()
    {
        int id = 404;
        foreach (var gate in logicGates)
        {
            if (gate.logic != null && gate.logic.gameObject != null && gate.logic.gameObject.activeSelf)
            {
                id = gate.Id;
                break;
            }
        }

        return id != 404;
    }

    public virtual void SocetIsGate()
{
    bool anyActive = false;

    foreach (GateClass gate in logicGates)
    {
        if (gate.logic != null && gate.logic.gameObject != null && gate.logic.gameObject.activeSelf)

        {
            anyActive = true;
            break;
        }
    }

    
    if (anyActive != previousSocketState)
    {
        if (finish != null)
        {
            if (anyActive)
            {
                finish.soketnumberAdd++;
            }
            else
            {
                finish.soketnumberAdd--;
            }
        }
        else
        {
            Debug.LogWarning("Finish nesnesi null! Sahneye eklenmemiş olabilir.");
        }

        previousSocketState = anyActive;
    }

    }


}
