using UnityEngine;

public class Levyer : BaseSet
{
    // public bool _set;
    public GameObject _leverClosed;
    public GameObject _leverOpened;
    public bool Lever_set;
   private LevyerDetectorm detector;

    void Start()
    {
        detector=GetComponent<LevyerDetectorm>();
    }
    private void Update()
    {
        
        if (Lever_set)
        {
            SetLever();
        }
    }
    

    void SetLever()
    {
        if (detector.GetEnter())
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

    public override bool GetSet()
    {
       return detector.GetEnter();
    }
}
