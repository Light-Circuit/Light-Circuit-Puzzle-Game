using UnityEngine;

public class Nand : LogicGate
{
    public override bool Gate(bool input1, bool input2)
    {
        return !(input1 && input2);
    }
}
