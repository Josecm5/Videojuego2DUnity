using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb;
    public float moveSpeed;
    Animator myAnim;

    [HideInInspector]
    public bool facingRight = true;

    public float checkRadius = 0.1f;
    public Transform GroundCheck;
    public LayerMask target;

    bool isGrounded = true;

    public float jumpForce;

    public float boundaryMargin = 0.2f;

    bool jumpAllowed, wallJumpAllowed;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        myAnim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(GroundCheck.position, checkRadius, target);

        myAnim.SetBool("grounded", isGrounded);
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        Jump();

        if (rb.velocity.y == 0 || wallJumpAllowed)
            jumpAllowed = true;
        else
            jumpAllowed = false;
        
        if (Input.GetButtonDown ("Jump") && jumpAllowed)
            Jump ();
    }

    void MovePlayer()
    {
        float move = Input.GetAxisRaw("Horizontal") * moveSpeed;

        rb.velocity = new Vector2(move, rb.velocity.y);

        if (move > 0 && !facingRight || move < 0 && facingRight)
            FlipPlayer();

        myAnim.SetFloat("speed", Mathf.Abs(move));
        
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 10)).x;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 10)).x;

        rb.position = new Vector2(Mathf.Clamp(rb.position.x, minX + boundaryMargin, maxX - boundaryMargin), rb.position.y);

    }

    void FlipPlayer()
    {
        facingRight = !facingRight;

        Vector3 scale = transform.localScale;

        scale.x *= -1;

        transform.localScale = scale;
    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            SoundManagerScript.PlaySound ("jump");
            rb.velocity = Vector2.up * jumpForce;
        }

        myAnim.SetFloat("vSpeed",rb.velocity.y);
    }

    void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Wall")) {
            wallJumpAllowed = true;
        }
    }

    void OnCollisionExit2D (Collision2D col)
    {
        if (col.gameObject.tag.Equals ("Wall"))
            wallJumpAllowed = false;
    }
}
