using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Input;



public class CharacterInteract : MonoBehaviour
{
    public GameObject x;
    
    public GameObject panel;
    public Selector selector;
    private LevyerDetectorm levyerInteract;
    private IBaseSocet SocetInteract;
    private EnvanterSystem envanter;
    private bool canInteract = false;
   


    private InputManager inputManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
       
    }
    void Start()
    {
         envanter=GetComponent<EnvanterSystem>();
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
            if(socet is InteractableSocet)
            {
                SocetInteract = socet;
                panel.SetActive(true);
            }
            if(socet is CollectAbleSocet collectAble)
            {
                SocetInteract = socet;
                x.SetActive(!collectAble.is_Collect);
              
            }
            if(socet is CollectInteractSocet collectInteract)
            {
                SocetInteract=socet;
               
                   x.SetActive(collectInteract.GateAviable());
                   panel.SetActive(!collectInteract.GateAviable());
                

            }
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
                x.SetActive(false);
                SocetInteract = null;
            }
        }
    }

   private void Update()
    {
        if (inputManager.KeyE)
        {
            if (levyerInteract is LevyerDetectorm)
            {
                Debug.Log("Sadece levyerde çalışıyorum");
                HandleLevyerInteraction();
            }

            if (SocetInteract is InteractableSocet && SocetInteract is not CollectInteractSocet)
            {
                Debug.Log("Sadece interactable çalışıyorum");
                HandleSocetAddInteraction();
            }

            if (SocetInteract is CollectAbleSocet && SocetInteract is not CollectInteractSocet)
            {
                Debug.Log("Sadece Collectable çalışıyorum");
                HandleSocetCollectInteraction();
            }

            if (SocetInteract is CollectInteractSocet collectSocet)
            {
                Debug.Log("Sadece collectSocetde çalışırım");

                if (collectSocet.GateAviable())
                    HandleSocetCollectInteraction();
                else
                    HandleSocetAddInteraction();
            }
        }
        //panel üzerinde silme işlemi kaldırıldı
        // if (inputManager.KeyOne)
        // {
        //     HandleSocetRemoveInteraction();
        // }
    }

    private void HandleLevyerInteraction()
    {
        if (!canInteract || levyerInteract == null) return;
        bool current = levyerInteract.GetEnter();
        levyerInteract.SetEnter(!current);
    }

    private void HandleSocetAddInteraction()
    {
        if (SocetInteract == null || selector == null || selector.selectedObject == null)
        {
            Debug.LogWarning("SocetInteract, selector veya selectedObject null.");
            return;
        }

        KeyGate keyGate = selector.selectedObject.GetComponent<KeyGate>();
        if (keyGate == null || keyGate.keyBinding == null)
        {
            Debug.LogWarning("KeyGate ya da keyBinding null.");
            return;
        }

        int keyId = keyGate.keyBinding.Id;
        Debug.Log($"Seçilen Anahtar ID: {keyId}");

        if (envanter == null)
        {
            Debug.LogError("envanter is null!");
            return;
        }

        if (!envanter.HasStock(keyId))
        {
            Debug.Log("Stok yok, işlem yapılmadı.");
            return;
        }

        Debug.Log("Stok var, işlem deneniyor...");

        if (SocetInteract is InteractableSocet interactable)
        {
            interactable.AddLogic(keyId);
            envanter.DecStock(keyId);
            panel.SetActive(false);
        }
        else if (SocetInteract is CollectInteractSocet collectable)
        {
            if (collectable.is_Collect)
            {
                int collectedId = collectable.Collect();
                if (collectedId == keyId)
                {
                    Debug.Log("Collect ID eşleşti, işlem başarılı.");
                    envanter.DecStock(keyId);
                    panel.SetActive(false);
                }
                else
                {
                    Debug.LogWarning($"Collect ID ({collectedId}) anahtar ID ({keyId}) ile eşleşmedi.");
                }
            }
            else
            {
                Debug.Log("Soket boş, Add işlemi yapılıyor...");
                collectable.AddLogic(keyId);
                envanter.DecStock(keyId);
                panel.SetActive(false);
            }
        }
        else
        {
            Debug.LogWarning("SocetInteract tanınan bir soket tipi değil.");
        }

   
        if (SocetInteract is CollectInteractSocet collectSocet)
        {
            if (collectSocet.is_Collect)
            {
                x.SetActive(true); 
            }
        }
    }


    private void HandleSocetCollectInteraction()
    {
        if (SocetInteract == null)
        {
            Debug.LogWarning("SocetInteract is null!");
            return;
        }

        if (envanter == null)
        {
            Debug.LogError("envanter is null!");
            return;
        }

        if (SocetInteract is IBaseSocet collectable)
        {
            int id = collectable.Collect();
            Debug.Log("Collected ID: " + id);

            if (id != 404)
            {
                envanter.AddStock(id);

              
                bool shouldShowPanel = false;

                if (SocetInteract is CollectAbleSocet col)
                    shouldShowPanel = !col.is_Collect;
                else if (SocetInteract is CollectInteractSocet colInt)
                    shouldShowPanel = !colInt.is_Collect;

                x.SetActive(false);
                panel.SetActive(shouldShowPanel);
            }
            else
            {
                Debug.LogWarning("Geçersiz Collect ID döndü.");
            }
        }
        else
        {
            Debug.LogWarning("SocetInteract ICollectable değil!");
        }
    }




    // private void HandleSocetRemoveInteraction()
    // {
       
    //     if (SocetInteract == null ) return;
    //     if(SocetInteract is InteractableSocet interactable)
    //     {
    //         int id=interactable.GetGate();
    //         if (id != 404)
    //         {
    //             envanter.AddStock(id);
    //         }
    //         interactable.RemoveLogic();
    //     } 
    // }




}
