using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Logic : MonoBehaviour
{
    public string gateName;
    public bool result;
    public Setter[] setter;

    private string lastGateName; // Önceki kapý türünü saklamak için
    private bool lastResult; // Önceki sonucu saklamak için

    private void Start()
    {
        lastGateName = gateName;
        lastResult = result;
    }

    private void Update()
    {
        Gate(gateName, setter[0].set, setter[1].set);
        Result();

        // **Mantýk kapýsý deðiþtiðinde sadece devre birleþtirme sesi çalsýn**
        if (gateName != lastGateName)
        {
            lastGateName = gateName;

            if (AudioManager.instance != null)
            {
                //AudioManager.instance.PlayCircuitConnectSound(); // **Sadece devre sesi çalacak**
            }
        }
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

        // Eðer sonuç deðiþirse devre sesi çalacak, buton sesi çýkmayacak
        if (result != lastResult)
        {
            lastResult = result;

            //if (AudioManager.instance != null)
            //{
            //    AudioManager.instance.PlayCircuitConnectSound(); // **Buton sesi deðil, devre sesi çalacak**
            //}
        }
    }
}
