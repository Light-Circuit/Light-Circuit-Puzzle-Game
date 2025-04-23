using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool _set;
    public GameObject _leverClosed;
    public GameObject _leverOpened;
    public bool LeverSET;

    private void Update()
    {
        
        if (LeverSET)
        {
            SetLever();
        }
    }
    

    void SetLever()
    {
        if (_set)
        {
            _leverClosed.SetActive(false);
            _leverOpened.SetActive(true);
        }
        else
        {
            _leverOpened.SetActive(false);
            _leverClosed.SetActive(true);
        }

    }
   
}
