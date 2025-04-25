using UnityEngine;
//tek kullanımlık soket kaldırılmıştır
public class InteractableSocet : BaseSocet 
{
    public bool is_on;
    void Update()
    {
        SocetRule();
    }
    public override void AddLogic(int id)
     {
        base.AddLogic(id);
     }
     public override void RemoveLogic(){
        base.RemoveLogic();
     }
    public override void SocetRule()
    {
        base.SocetRule();
    }
   public int GetGate(){
    
    int id = 404;
    foreach (var gate in logicGates)
    {
        if (gate.logic != null && gate.logic.gameObject != null && gate.logic.gameObject.activeSelf)
        {
            id = gate.Id;
            break;
        }
    }

    return id; 
   }
}