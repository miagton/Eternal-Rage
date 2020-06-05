using System;
using System.Collections;
using System.Collections.Generic;
//using System.Numerics;
using UnityEditor;

using UnityEngine;


public class Character : MonoBehaviour
{
    float MaxHealth = 1.0f;
   public  float CurrentHealth;
    public float Speed = 5;
    Rigidbody2D _rigidbody2D;
   //переменная для горизонтального движения
    float _PlayerInput;

    public LayerMask WhatIsGround;

    public float JumpForce;

    //Блок переменных для IsGrounded
    bool _isGrounded;
    public Transform feetPose;
    public float CheckRadius;
    public GameObject Arrow;
    Vector3 ArrowPosition;
    float horizontalmove = 0f;
   
    
    float _JumptimeCounter;
    public float JumpTime;
    bool _IsJumping;

    public Animator animator;

    
   
    public float RollPower = 0.1f;

    public GameObject Dead;
    GameObject Healthbar;

    //private SpriteRenderer sprite;

    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        CurrentHealth = MaxHealth;
        Healthbar = GameObject.Find("HealthBar");
        // sprite = GetComponentInChildren<SpriteRenderer>();
        ArrowPosition = GameObject.Find("FirePoint").transform.position;

    }

   

    private void FixedUpdate()//используеться для манипуляций над всеми елементами игры связяными с физикой
    {

        
    }
    void Update()
    {
       TurnSprite();
       Jump();
        //if (Input.GetButton("Horizontal")) 
       Run();
       

       

    }

     void TurnSprite()
     {
         if (_PlayerInput > 0)
         {
             transform.eulerAngles = new Vector3(0, 0, 0);
         }
         else if (_PlayerInput < 0)
         {
             transform.eulerAngles = new Vector3(0, 180, 0);
         }
     }
    void Run()
        {
        
        //Делаем движение по оси Х
        //velocity предаваемое ускорение отдельно по Х и У
        Vector3 direction = transform.right * Input.GetAxisRaw("Horizontal");
        _PlayerInput = Input.GetAxisRaw("Horizontal");
        horizontalmove = _PlayerInput * Speed;
        animator.SetFloat("Speed",Math.Abs(horizontalmove));

        if (Input.GetAxis("Horizontal") > 0)
        {
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direction, Speed * Time.deltaTime);
           
        }
       
        else if(Input.GetAxis("Horizontal") < 0) { 
            transform.position = Vector3.MoveTowards(transform.position, transform.position - direction, Speed * Time.deltaTime);
            ;
        }
            

       //sprite.flipX = direction.x < 0.0F;


     //  _rigidbody2D.velocity = new Vector2(_PlayerInput * Speed, _rigidbody2D.velocity.y);
       
       
       
        
    }
    void Jump()
    {
        _isGrounded = Physics2D.OverlapCircle(feetPose.position, CheckRadius, WhatIsGround );
           
        if (_isGrounded == true && Input.GetKeyDown(KeyCode.W))
        {
            animator.SetTrigger("Jump");
            _rigidbody2D.velocity = Vector2.up * JumpForce;
            _IsJumping = true;
            _JumptimeCounter = JumpTime;
        }

        if (Input.GetKey(KeyCode.W) && _IsJumping == true)
        {
            if (_JumptimeCounter > 0)
            {
                _rigidbody2D.velocity = Vector2.up * JumpForce;
                _JumptimeCounter -= Time.deltaTime;
            }
            else
            {
                _IsJumping = false;
            }

        }
        if (Input.GetKeyUp(KeyCode.W))
        {
            
            _IsJumping = false;
        }

    }
   
   


    public void TakeDamage(float damage)
    {
        
            CurrentHealth -= damage;
           // animator.SetTrigger("Hit");

        Healthbar.GetComponent<HealthBarFade>().SetHealth(CurrentHealth);

            if (ArrowPosition.x < transform.position.x)
            {
            _rigidbody2D.velocity = new Vector3(5, 5, 0);
            // _rigidbody2D.velocity = Vector3.zero;
            //_rigidbody2D.AddForce(transform.up * 100.0f, ForceMode2D.Impulse);
            // transform.position = new Vector3(transform.position.x + 0.2f , transform.position.y , transform.position.y);  enemie stops attack?
        }
            else if (ArrowPosition.x > transform.position.x)
            {
            _rigidbody2D.velocity = new Vector3(-5, 5, 0);
            // transform.position = new Vector3(transform.position.x - 0.2f , transform.position.y , transform.position.y); enemy stops attack?
            // _rigidbody2D.velocity = Vector3.zero;
            // _rigidbody2D.AddForce(-transform.up * 100.0f, ForceMode2D.Impulse);
        }
       
        if(CurrentHealth <= 0)
        {
            /* CurrentHealth = 0;
             gameObject.layer = LayerMask.NameToLayer("Dodge");
             animator.SetTrigger("Die");
             animator.SetTrigger("Dead");
             gameObject.GetComponent<Character>().enabled = false;
             gameObject.GetComponent<PlayerAttack>().enabled = false;
             gameObject.GetComponent<Shooting>().enabled = false;
            */
            Instantiate(Dead, transform.position, Quaternion.identity);
            Destroy(gameObject);

        }
        Debug.Log(CurrentHealth);
    }

    
   

}



 

