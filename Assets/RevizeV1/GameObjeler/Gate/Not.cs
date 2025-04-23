using UnityEngine;

public class Not : LogicGate
{
    public override bool Gate(bool input)
    {
        return !input;
    }
}
