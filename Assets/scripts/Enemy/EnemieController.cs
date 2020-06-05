using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class EnemieController : MonoBehaviour
{
    
    public float Speed;
    public float JumpForce;
    Rigidbody2D _rigidbody2D;
    float CheckRadius = 0.3f;
    public LayerMask WhatsIsGround;
    public float JumpTime;
    float _JumptimeCounter;
    public GameObject DeadBody;
    public Transform StrikePoint;

    bool _isNOGround;
   
    public Transform Feetpose;
  //  [SerializeField]
   // Vector3 PlayerPos;
    Transform Player;

    Vector3 _direction;
   public  Animator Animator;
    bool _isJumping;
    
   // public Transform Target;

    public int MaxHealth;
    [SerializeField]
    int _CurrentHealth;

    Vector3 newPosition;

    public int ScoreAward;
    
   
    
    
    
    
   
    void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _direction = transform.right;

        _CurrentHealth = MaxHealth;


        
        
    }



    private void Awake()
    {
        Player = GameObject.Find("Character").transform;
    }


    void Update()
    {
             
        Run();
        Jump();
        Die();
    }


    void Run()
    {
        // _rigidbody2D.velocity = new Vector2(-10.0F * Speed, _rigidbody2D.velocity.y);

        newPosition = new Vector3(Player.position.x, transform.position.y, 0);

        transform.position = Vector3.MoveTowards(transform.position, newPosition, Speed * Time.deltaTime);
       
        if ((Player.position.x - transform.position.x) > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if ((Player.position.x - transform.position.x) < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }
    }


    void Jump()
    {
       _isNOGround = Physics2D.OverlapCircle(Feetpose.position, CheckRadius, WhatsIsGround);
       
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position + transform.up * -0.6F + transform.right * -0.3F, 0.1F);

        if (colliders.Length <= 0  && _isNOGround == true)
        {
            // transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, _speed * Time.deltaTime);
            
           // _rigidbody2D.velocity = Vector2.up * JumpForce;
            _isJumping = true;
            _JumptimeCounter = JumpTime;
            _rigidbody2D.velocity = Vector2.up * JumpForce;
            //_rigidbody2D.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
        }
        if (_isJumping == true)
        {
            if (_JumptimeCounter > 0)
            {
                _rigidbody2D.velocity = Vector2.up * JumpForce;
                _JumptimeCounter -= Time.deltaTime;
                //_rigidbody2D.AddForce(transform.up * JumpForce, ForceMode2D.Impulse);
            }
            else
            {
                _isJumping = false;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + transform.up * -0.6F + transform.right * - 0.3F, 0.1F);
    }

   
     void Die()
    {
        if(_CurrentHealth <= 0)
        {
            UIManager Ui;
            Ui = GameObject.Find("UImanager").GetComponent<UIManager>();
            GameObject.Find("UImanager").GetComponent<UIManager>().Score+=ScoreAward;
            Ui.NewScore();
            Destroy(gameObject);
            Instantiate(DeadBody, transform.position, transform.rotation);
        }
    }

    public void TakeDamage(int damage)
    {
        Animator.SetTrigger("Hit");
        _CurrentHealth -= damage;
        if(StrikePoint.position.x < transform.position.x)
        {
            _rigidbody2D.velocity = new Vector2(2, 2);
        }
        else if(StrikePoint.position.x > transform.position.x)
        {
            _rigidbody2D.velocity = new Vector2(-2, 1);
        }
               
      
    }
  
}



