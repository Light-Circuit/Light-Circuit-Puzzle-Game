using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mert.Input;
using Unity.VisualScripting;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;
    private InputManager inputManager;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
        inputManager=GetComponent<InputManager>();
    }

    void Update()
    {
        PlayerMove();
    }


    private Coroutine moveCoroutine; 

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

        while((targetPos-transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, MoveSpeed*Time.deltaTime);
            yield return null;

        }
        transform.position = targetPos;

        isMoving = false;
    }




}
