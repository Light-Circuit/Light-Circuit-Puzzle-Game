using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    private bool isMoving;

    private Vector2 input;

    private Animator animator;
   
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        PlayerMove();
    }


    void PlayerMove()
    {
        if (!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            //Debug.Log("this is input.x" + input.x);
            //Debug.Log("this is input.y" + input.y);



         //if (input.x > 0) 
         //   { input.y = 0; }
         //  else if (input.x < 0)
         //   {  input.y = 0; }


            if (input != Vector2.zero)
            {

                animator.SetFloat("moveX", input.x);
                animator.SetFloat("MoveY", input.y);

                var TargetPos = transform.position;
                TargetPos.x += input.x;
                TargetPos.y += input.y;


                StartCoroutine(Move(TargetPos));

            }
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
