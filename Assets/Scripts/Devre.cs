using UnityEngine;

public class Devre : MonoBehaviour
{
    public Logic[] activeLogic;
    public bool devreSetter;
    [SerializeField] bool anyActive = false;

    private void Update()
    {
        foreach (var item in activeLogic)
        {
            if (item.gameObject.activeSelf)
            {
                devreSetter = item.result;
                anyActive = true;
                break;
            }
            else
            {
                anyActive = false;
            }



        }


        if (!anyActive)
        {
            devreSetter = false;
        }


    }
}
