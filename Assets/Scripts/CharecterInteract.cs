using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Input;
using System.Net.Sockets;

public class CharacterInteract : MonoBehaviour
{
    public GameObject x;
   
    public GameObject OgreticiPanel;
    private AudioManager manager;
    public GameObject panel;
    public GameObject BufandNotPanel;
    private Selector selector;
    private LevyerDetectorm levyerInteract;
    private IBaseSocet SocetInteract;
    private EnvanterSystem envanter;
    private bool canInteract = false;
    [HideInInspector]public bool isTutorialActive = false;
    

    [HideInInspector] public Tutorial _tutorials;

    private InputManager inputManager;

    private void Awake()
    {
        inputManager = GetComponent<InputManager>();
    }

    void Start()
    {
        envanter = GetComponent<EnvanterSystem>();
        manager = FindAnyObjectByType<AudioManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<Tutorial>(out var tutorial))
        {
            if (!tutorial.isShow)
            {
                _tutorials = tutorial;
                OgreticiPanel.SetActive(true);
                isTutorialActive = true;
                tutorial.isShow=true;
            }
        }

       if (collision.gameObject.TryGetComponent<LevyerDetectorm>(out var detector))
        {
            levyerInteract = detector;

            if (isTutorialActive) return;

            if (levyerInteract.use_lever)
            {
                canInteract = true;
                x.SetActive(true); 
            }
}

        if (collision.gameObject.TryGetComponent<IBaseSocet>(out var socet))
        {
            SocetInteract = socet; 

            if (isTutorialActive) return; 

            if (socet is InteractableSocet)
            {
                panel.SetActive(true);
            }
            if (socet is CollectAbleSocet collectAble)
            {
                x.SetActive(!collectAble.is_Collect);
            }
            if (socet is CollectInteractSocet collectInteract)
            {
                x.SetActive(collectInteract.GateAviable());
                panel.SetActive(!collectInteract.GateAviable());
            }
            if (socet is ColinteractOne colinteractOne)
            {
                x.SetActive(colinteractOne.GateAviable());
                BufandNotPanel.SetActive(!colinteractOne.GateAviable());
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
                BufandNotPanel.SetActive(false);
                panel.SetActive(false);
                x.SetActive(false);
                SocetInteract = null;
            }
        }
    }

    private void Update()
    {
        if (isTutorialActive && inputManager.KeyE)
        {
            OgreticiPanel.SetActive(false);
            isTutorialActive = false;

          
            if (SocetInteract != null)
            {
                if (SocetInteract is InteractableSocet)
                {
                    panel.SetActive(true);
                }
                else if (SocetInteract is CollectAbleSocet collectAble)
                {
                    x.SetActive(!collectAble.is_Collect);
                }
                else if (SocetInteract is CollectInteractSocet collectInteract)
                {
                    x.SetActive(collectInteract.GateAviable());
                    panel.SetActive(!collectInteract.GateAviable());
                }
                else if (SocetInteract is ColinteractOne colinteractOne)
                {
                    x.SetActive(colinteractOne.GateAviable());
                    BufandNotPanel.SetActive(!colinteractOne.GateAviable());
                }
            }

            if (levyerInteract != null)
            {
                x.SetActive(true);
            }

            return; 
        }

        if (inputManager.KeyE)
        {
            if (levyerInteract is LevyerDetectorm)
            {
                manager.LevyerSound();
                HandleLevyerInteraction();
            }

            if (SocetInteract is CollectAbleSocet && SocetInteract is not CollectInteractSocet)
            {
                HandleSocetCollectInteraction();
            }

            if (SocetInteract is CollectInteractSocet collectSocet)
            {
                GameObject selectorObj = GameObject.FindGameObjectWithTag("MainSelector");
                if (selectorObj != null)
                    selector = selectorObj.GetComponent<Selector>();           

                if (collectSocet.GateAviable())
                {
                    HandleSocetCollectInteraction();
                }
                else
                {
                    manager.AddSound();
                    HandleSocetAddInteraction();
                }
            }
            if (SocetInteract is ColinteractOne c)
            {
                GameObject selectorObj = GameObject.FindGameObjectWithTag("SecondSelector");
                if (selectorObj != null)
                    selector = selectorObj.GetComponent<Selector>();           

                if (c.GateAviable())
                {
                    HandleSocetCollectInteraction();
                }
                else
                {
                    manager.AddSound();
                    HandleSocetAddInteraction();
                }
            }
        }
    }

    private void HandleLevyerInteraction()
    {
        if (!canInteract || levyerInteract == null || !levyerInteract.use_lever) return;

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
            manager.noneSound();
            return;
        }

        Debug.Log("Stok var, işlem deneniyor...");

        if (SocetInteract is InteractableSocet interactable)
        {
            interactable.AddLogic(keyId);
            envanter.DecStock(keyId);
            manager.AddSound();
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
        else if (SocetInteract is ColinteractOne one)
        {
            if (one.is_Collect)
            {
                int collectedId = one.Collect();
                if (collectedId == keyId)
                {
                    Debug.Log("Collect ID eşleşti, işlem başarılı.");
                    envanter.DecStock(keyId);
                    BufandNotPanel.SetActive(false);
                }
                else
                {
                    Debug.LogWarning($"Collect ID ({collectedId}) anahtar ID ({keyId}) ile eşleşmedi.");
                }
            }
            else
            {
                Debug.Log("Soket boş, Add işlemi yapılıyor...");
                one.AddLogic(keyId);
                envanter.DecStock(keyId);
                BufandNotPanel.SetActive(false);
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
                manager.CollectSound();
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
}
