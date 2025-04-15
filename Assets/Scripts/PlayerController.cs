using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float MoveSpeed = 5f; // Varsayılan hız
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

        if (!isMoving) // Eğer hareket etmiyorsa giriş al

        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if (input != Vector2.zero) // Eğer giriş varsa hareket et
            {

                animator.SetFloat("MoveX", input.x);
                animator.SetFloat("MoveY", input.y);
                animator.SetBool("isMoving", true); //  HAREKET BAŞLAYINCA ANİMASYONU AKTİF ET

                var TargetPos = transform.position;
                TargetPos.x += input.x;
                TargetPos.y += input.y;

                StartCoroutine(Move(TargetPos));

                if (!audioSource.isPlaying && AudioManager.instance != null)
                {
                    audioSource.clip = AudioManager.instance.WalkSound;
                    audioSource.Play();
                }

                StartMoving();

            }
            else
            {
                StopMoving();
            }
        }
    }

    void StartMoving()
    {
        animator.SetFloat("moveX", input.x);
        animator.SetFloat("moveY", input.y);
        animator.SetBool("isMoving", true);

        Vector3 targetPos = transform.position + new Vector3(input.x, input.y, 0);
        StartCoroutine(Move(targetPos));

        if (!audioSource.isPlaying && AudioManager.instance != null)
        {
            audioSource.clip = AudioManager.instance.WalkSound;
            audioSource.Play();
        }
    }

    void StopMoving()
    {
        animator.SetBool("isMoving", false);

        if (audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while ((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, MoveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;

        if (Input.GetAxisRaw("Horizontal") == 0 && Input.GetAxisRaw("Vertical") == 0)
        {
            StopMoving();
        }
    }
}
