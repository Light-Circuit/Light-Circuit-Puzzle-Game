using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class Panel : MonoBehaviour
{
    [Header("and,or,not,xor")]
    [Header("# x o A")]
    public GameObject[] _gate;
    private void Update()
    {
        GamePad();
    }
    void Touch()
    {

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 ray = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(ray, Vector2.zero);
            if (hit.collider != null)
            {
                Panels(hit);


            }
        }
    }
    public void Panels(RaycastHit2D hit)
    {
        Debug.Log(hit.collider.tag);
        Panel_Btn(hit, "and_gate", 0);
        Panel_Btn(hit, "or_gate", 1);
        Panel_Btn(hit, "not_gate", 2);
        Panel_Btn(hit, "xor_gate", 3);
        Panel_Btn(hit, "nand_gate", 4);
        Panel_Btn(hit, "nor_gate", 5);


        if (hit.collider.CompareTag("delete_gate"))
        {
            foreach (var g in _gate) { g.SetActive(false); }

        }


    }
    private void closed()
    {

        foreach (var item in _gate)
        {
            item.SetActive(false);
            SocketSound();
        }


    }
    private void Panel_Btn(RaycastHit2D hit, string gate_name, int a)
    {
        if (hit.collider.CompareTag(gate_name))
        {
            closed();
            _gate[a].SetActive(true);

        }

    }


    void GamePad()
    {

        //kare x o ??gen0
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log(" kare ");
            closed();
            _gate[0].SetActive(true);
            SocketSound();


        }
        if (Input.GetButtonDown("Fire2"))
        {
            Debug.Log(" x ");
            closed();
            _gate[1].SetActive(true);
            SocketSound();
        }
        if (Input.GetButtonDown("Fire3"))
        {
            Debug.Log(" daire ");
            closed();
            _gate[2].SetActive(true);
            SocketSound();
        }
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("ucgen");
            closed();

        }



    }

    public void SocketSound()
    {
        AudioManager.instance.PlayCircuitConnectSound();
    }

}
