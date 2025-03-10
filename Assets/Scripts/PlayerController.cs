using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed;

    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        audioSource.loop = true;
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

            if (input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);
                animator.SetBool("isMoving", true); // 🔹 HAREKET BAŞLAYINCA ANİMASYONU AKTİF ET

                var TargetPos = transform.position;
                TargetPos.x += input.x;
                TargetPos.y += input.y;

                StartCoroutine(Move(TargetPos));

                if (!audioSource.isPlaying && AudioManager.instance != null)
                {
                    audioSource.clip = AudioManager.instance.WalkSound;
                    audioSource.Play();
                }
            }
            else
            {
                animator.SetBool("isMoving", false); // 🔹 HAREKET DURUNCA ANİMASYONU KAPAT
                isMoving = false;

                if (audioSource.isPlaying)
                {
                    audioSource.Stop();
                }
            }
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        animator.SetBool("isMoving", true); // 🔹 ANİMASYONU BAŞLAT

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, MoveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
        animator.SetBool("isMoving", false); // 🔹 ANİMASYONU DURDUR

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }
}
