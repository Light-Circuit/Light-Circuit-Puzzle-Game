using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mert.Input;

public class CharacterInteract : MonoBehaviour
{
    public GameObject x;
    public GameObject panel;
    public Selector selector;
    private LevyerDetectorm levyerInteract;
    private IBaseSocet SocetInteract;
    private bool canInteract = false;
    private bool hasInteracted = false;

    private InputManager inputManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<LevyerDetectorm>(out var detector))
        {
            levyerInteract = detector;
            canInteract = true;
            x.SetActive(true);
        }

        if (collision.gameObject.TryGetComponent<IBaseSocet>(out var socet))
        {
            SocetInteract = socet;
            panel.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<LevyerDetectorm>(out var detector))
        {
            if (levyerInteract == detector)
            {
                canInteract = false;
                x.SetActive(false);
                levyerInteract = null;
            }
        }

        if (collision.gameObject.TryGetComponent<IBaseSocet>(out var socet))
        {
            if (socet == SocetInteract)
            {
                panel.SetActive(false);
                SocetInteract = null;
            }
        }
    }

private void Update()
{
    

    if (inputManager.KeyE)
    {
        Debug.Log("E ye basıyom");
        HandleLevyerInteraction();
        HandleSocetAddInteraction();

    }
    if(inputManager.KeyOne)
    {
        Debug.Log("X tuşuna basıyorum");
        HandleSocetRemoveInteraction();

    }
   
}

private void HandleLevyerInteraction()
{
    if (!canInteract || levyerInteract == null) return;
    bool current = levyerInteract.GetEnter();
    levyerInteract.SetEnter(!current);
}

private void HandleSocetAddInteraction()
{
    if (SocetInteract == null || selector.selectedObject == null) return;
    SocetInteract.AddLogic(selector.selectedObject.GetComponent<KeyGate>().keyBinding.Id);
}
private void HandleSocetRemoveInteraction()
{
    if (SocetInteract == null ) return;
    SocetInteract.RemoveLogic();
}




}
