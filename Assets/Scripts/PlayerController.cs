using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float movementSpeed = 5f;
    [SerializeField] float shiftSpeed = 40f;
    [SerializeField] float jumpForce = 7f;
    float currentSpeed;
    Rigidbody rb;
    Vector3 direction;

    [SerializeField] float stamina = 5f;

    [SerializeField] Animator animator;

    bool isGrounded = true;

    [SerializeField] AudioSource runSound;

    [SerializeField] AudioClip jumpSound;

    //[SerializeField] Image RightUpSight;
    //[SerializeField] Image RightDownSight;
    //[SerializeField] Image LeftUpSight;
    //[SerializeField] Image LeftDownSight;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        currentSpeed = movementSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        direction = new Vector3(moveHorizontal, 0.0f, moveVertical);
        direction = transform.TransformDirection(direction);

        if (direction.x != 0 || direction.z != 0)
        {
            animator.SetBool("Walk", true);
            //RightUpSight.transform.Translate(Vector2.right * 4 * Time.deltaTime);
            //RightUpSight.transform = Mathf.Clamp(60, 40, 0);
        }
        if (direction.x == 0 && direction.z == 0)
        {
            animator.SetBool("Walk", false);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (stamina > 0)
            {
                stamina -= Time.deltaTime;
                currentSpeed = shiftSpeed;
                animator.SetBool("Run", true);

                if (!runSound.isPlaying && isGrounded)
                {
                    runSound.Play();
                }
            }
            else
            {
                currentSpeed = movementSpeed;
                animator.SetBool("Run", false);
            }
        }

        else if (!Input.GetKey(KeyCode.LeftShift))
        {
            stamina += Time.deltaTime;
            currentSpeed = movementSpeed;
            animator.SetBool("Run", false);

            runSound.Stop();
        }

        if (stamina > 5f)
        {
            stamina = 5f;
        }
        else if (stamina < 0)
        {
            stamina = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
            isGrounded = false;
            runSound.Stop();
            AudioSource.PlayClipAtPoint(jumpSound, transform.position);
        }

        if (!isGrounded)
        {
            animator.SetBool("Jump", true);
        }
        else
        {
            animator.SetBool("Jump", false);
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(transform.position + direction * currentSpeed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        isGrounded = true;
    }
}
