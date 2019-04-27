using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private float horizontalSpeed;
    private float verticalSpeed;

    private Rigidbody2D rb;
    public Animator animator;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    private int extraJumps;
    public int extraJumpsValue;

    private GameObject player;
    private GameManagerScript gm;

    public AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        extraJumps = extraJumpsValue;
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.Find("Player");
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManagerScript>();

        source = GetComponent<AudioSource>();

    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        verticalSpeed = rb.velocity.y;

        moveInput = Input.GetAxisRaw("Horizontal");
        //Debug.Log(moveInput);
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if (facingRight != true && moveInput > 0)
        {
            Flip();
        }
        else if (facingRight == true && moveInput < 0)
        {
            Flip();
        }

        if (verticalSpeed <= -20)
        {
            Die();
        }

    }

    void Update()
    {
        horizontalSpeed = rb.velocity.x;
        //verticalSpeed = rb.velocity.y;

        animator.SetFloat("speed", Mathf.Abs(horizontalSpeed));
        animator.SetBool("isJump", !isGrounded);

        if (isGrounded == true)
        {
            extraJumps = extraJumpsValue;
        }
        if (Input.GetKeyDown(KeyCode.Space) && extraJumps > 0)
        {
            rb.velocity = Vector2.up * jumpForce;
            extraJumps--;
        }
        else if (Input.GetKeyDown(KeyCode.Space) && extraJumps == 0 && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            gm.coins += 1;
            source.Play();
        }

        if (other.CompareTag("Key"))
        {
            if (gm.isKey == false)
            {
                gm.isKey = true;
                Destroy(other.gameObject);
                source.Play();
            }
        }

        if (other.CompareTag("Enemy"))
        {
            Die();
        }
    }

    public void Die()
    {
        animator.SetTrigger("die");
        rb.velocity = Vector3.zero;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        gm.EndGame();
    }
}
