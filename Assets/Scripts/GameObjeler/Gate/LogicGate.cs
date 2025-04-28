using UnityEngine;

public abstract class LogicGate : MonoBehaviour
{
   
    public virtual bool Gate(bool input1, bool input2){return false;}
    public virtual bool Gate(bool input){return false;}
}
