using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Input;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{   
    private AudioManager manager;
    public float MoveSpeed;
    private InputManager inputManager;
    public float maxX, minX, maxY, minY;
    public GameObject PauseMenu;
    private bool isMoving;

    private Vector2 input;

    private Animator animator;
    private Coroutine moveCoroutine; 
    private CharacterInteract characterInteract;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager = GetComponent<InputManager>();
        manager = FindAnyObjectByType<AudioManager>();
        characterInteract = GetComponent<CharacterInteract>();
       
       
    }
    
    void Update()
    {
        if (characterInteract.isTutorialActive) return;
        if (PauseMenu.activeSelf) return;
        limitPos();
        PlayerMove();
        
    }

    private void limitPos()
    {
        Vector2 pos = transform.position;
        pos.x = Mathf.Clamp(pos.x, minX, maxX);
        pos.y = Mathf.Clamp(pos.y, minY, maxY);
        transform.position = pos;
    }
  

void PlayerMove()
{
    input.x = inputManager.move.x;
    input.y = inputManager.move.y;

    if (input != Vector2.zero && !isMoving)
    {
        animator.SetFloat("moveX", input.x);
        animator.SetFloat("MoveY", input.y);

        var TargetPos = transform.position + new Vector3(input.x, input.y, 0f);

        if (moveCoroutine != null)
            StopCoroutine(moveCoroutine); 

        moveCoroutine = StartCoroutine(Move(TargetPos));
    }
    else if (input == Vector2.zero && moveCoroutine != null)
    {
        StopCoroutine(moveCoroutine); 
        moveCoroutine = null;
        isMoving = false;
    }

    animator.SetBool("isMoivng", isMoving); 
}



    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        manager.WalkSound();
        while((targetPos-transform.position).sqrMagnitude > Mathf.Epsilon)
        {
transform.position = Vector3.MoveTowards(transform.position, targetPos, MoveSpeed*Time.deltaTime);
            yield return null;

        }
        transform.position = targetPos;

        isMoving = false;
    }




}
