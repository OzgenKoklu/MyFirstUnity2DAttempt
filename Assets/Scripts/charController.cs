using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charController : MonoBehaviour
{
    public float speed = 1.0f; 
    private Rigidbody2D r2d;
    private Animator _animator;
    private Vector3 charPos;
    private SpriteRenderer _SpriteRenderer;
    [SerializeField] private GameObject _camera;
    private int sayi;


    void Start()
    {
        _SpriteRenderer = GetComponent<SpriteRenderer>();
        r2d = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>(); 
        charPos = transform.position;
        sayi = 1;
        //Debug.Log("start" + sayi);

    }

    private void FixedUpdate()
    {
        //Debug.Log("fixed" + sayi);
        //r2d.velocity = new Vector2(speed, 0f);
        sayi = 2;
        
    }

    void Update()
    {
        /*if (Input.GetKey(KeyCode.Space)) //  public float speed = 0.0 için kod
        {
            speed = 1.0f;
           // Debug.Log("Hiz 1.0f");
        } else
        {
            speed = 0.0f;
           // Debug.Log("Hiz 0.0f");
        } */
        //charPos = new Vector3(charPos.x + (speed * Time.deltaTime), charPos.y);
        charPos = new Vector3(charPos.x + (Input.GetAxis("Horizontal")*speed*Time.deltaTime), charPos.y);
        transform.position = charPos;
        if(Input.GetAxis("Horizontal") == 0.0f)
        {
            _animator.SetFloat("speed", 0.0f);
        }else
        {
            _animator.SetFloat("speed", 1.0f);
        }

        if(Input.GetAxis("Horizontal") > 0.01f)
        {
            _SpriteRenderer.flipX = false;
        }else if(Input.GetAxis("Horizontal") < -0.01f){
            _SpriteRenderer.flipX = true;
        }
       // _animator.SetFloat("speed", speed);

        sayi = 3;
        //Debug.Log("updatefinal" + sayi);
    }

    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(charPos.x, charPos.y, charPos.z - 1.0f);
        sayi = 4;
    }
}
