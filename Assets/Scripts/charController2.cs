using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController2: MonoBehaviour
{
    [SerializeField] private float jumpForce =7.5f;
    [SerializeField] private float speed =4.0f;
    private float moveDirection;

    private bool jump;
    private bool grounded = true;
    private bool moving;
    private Rigidbody2D _rigidbody2d;
    private SpriteRenderer _spriteRenderer;
    private Animator anim;

    private void Awake()
    {
        anim = GetComponent<Animator>();

    }

     void Start()
    {
        _rigidbody2d = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        if(_rigidbody2d.velocity != Vector2.zero)
        {
            moving = true;
        } else
        {
            moving = false;
        }

        _rigidbody2d.velocity = new Vector2(6.5f*speed*moveDirection, _rigidbody2d.velocity.y);
        if(jump == true){
            _rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, jumpForce);
            jump = false;
        }
    }
    private void Update()
    {


        if (grounded == true && (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D)))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDirection = -1.0f;
                _spriteRenderer.flipX = true;
                anim.SetFloat("speed", speed);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                moveDirection = 1.0f;
                _spriteRenderer.flipX = false;
                anim.SetFloat("speed", speed);
            }
        }
        else if (grounded == true)
        {
            moveDirection = 0.0f;
            anim.SetFloat("speed", 0.0f);
        }

        if (grounded == true && Input.GetKey(KeyCode.W))
        {
            jump = true;
            grounded = false;
            anim.SetTrigger("jump");
            anim.SetBool("grounded", false);
        }
    }

    private void LateUpdate()
    {
      
    
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            anim.SetBool("grounded", true);
            grounded = true;
        } 
    }

}
