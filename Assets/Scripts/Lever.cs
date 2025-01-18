using UnityEngine;

public class Lever : MonoBehaviour
{
    public bool _set;
    public GameObject _leverClosed;
    public GameObject _leverOpened;
    public bool LeverSET;

    private void Update()
    {
        Touch();
        if (LeverSET)
        {
            SetLever();
        }
    }
    void Touch()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit.collider != null)
            {
                Debug.Log(hit.collider.gameObject.name);
                if (hit.collider.gameObject == _leverClosed)
                {
                    _set = true;


                }
                else if (hit.collider.gameObject == _leverOpened)
                {
                    _set = false;


                }
            }
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
