using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Windows;

public class Logic : MonoBehaviour
{
    public string gateName;
    public bool result;
    public BaseSet[] setter;

    private void Start()
    {
    }

    private void Update()
    {
        Gate(gateName, setter[0].GetSet(), setter[1].GetSet());
        Result();
    }

    private void Gate(string gateName, bool a, bool b)
    {
        switch (gateName)
        {
            case "and":
                result = a && b;
                break;
            case "or":
                result = a || b;
                break;
            case "not":
                result = !a;
                break;
            case "xor":
                result = a ^ b;
                break;
            case "nand":
                result = !(a && b);
                break;
            case "nor":
                result = !(a || b);
                break;
            case "xnor":
                result = !(a ^ b);
                break;
        }
    }

    public void Result()
    {
        if (result)
        {
            Debug.Log("ISIK Yandi");
        }
        else
        {
            Debug.Log("ISIK Yanmadi");
        }
    }
}
