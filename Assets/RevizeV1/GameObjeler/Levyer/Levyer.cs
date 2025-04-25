using UnityEngine;

public class Levyer : BaseSet
{
    // public bool _set;
    public Sprite _leverClosed;
    public Sprite _leverOpened;
    [Header("bunu kapatırsan lever basılabilir olmaz")]
    public bool Lever_set;
   private LevyerDetectorm detector;
   private SpriteRenderer spriteRenderer;

    void Start()
    {
        detector=GetComponent<LevyerDetectorm>();
        spriteRenderer=GetComponent<SpriteRenderer>(); 
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
            spriteRenderer.sprite=_leverOpened;
        }
        else
        {
           spriteRenderer.sprite=_leverClosed;
        }

    }

    public override bool GetSet()
    {
       return detector.GetEnter();
    }
}
