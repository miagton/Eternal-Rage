using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FLyingBoss : MonoBehaviour
{
   [SerializeField]
    int MaxHealth = 25;
    int _CurrentHealth;
    int Speed = 4;

    //int score;

   
    float _TimeBetwAttack;
    float StartTimeBetwAttack = 2f;

    public GameObject Projectile;
    public Animator animator;
    SpriteRenderer sprite;

    Vector3 _direction;

    GameObject Spawners;
    GameObject Spawners2;

    private void Awake()
    {
        _direction = transform.right;
        _CurrentHealth = MaxHealth;
        sprite = gameObject.GetComponent<SpriteRenderer>();
        Spawners = GameObject.Find("EnemySpawners");
        Spawners2 = GameObject.Find("EnemySpawners2");


       // score = GameObject.Find("UImanager").GetComponent<UIManager>().Score;
    }
    void Update()
    {
        
        Shoot();
        AttackTimer();
        Fly();
    }

    void AttackTimer()
    {
        _TimeBetwAttack -= Time.deltaTime;
        if (_TimeBetwAttack < 0)
        {
            _TimeBetwAttack = 0;
        }
    }

    void Shoot()
    {
        if (_TimeBetwAttack <= 0)
        {
            animator.SetTrigger("Shoot");
            Instantiate(Projectile, transform.position, Quaternion.identity);
            _TimeBetwAttack = StartTimeBetwAttack;
        }
           
       
    }



    public void TakeDamage(int damage)
    {
        animator.SetTrigger("Hit");
        _CurrentHealth -= damage;
       
        //add damage animation
        if (_CurrentHealth <= 0)
        {
            UIManager Ui;
            Ui = GameObject.Find("UImanager").GetComponent<UIManager>();
            Ui.NewScore();
            GameObject.Find("UImanager").GetComponent<UIManager>().Score += 20;
            Spawners.SetActive(true);
            Spawners2.SetActive(true);
            Destroy(gameObject);
        }

       
    }

    private void Fly()
    {
        transform.position = Vector3.MoveTowards(transform.position, transform.position + _direction, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (transform.position.x > 19)
        {
            _direction = -transform.right;
            sprite.flipX = true;
        }
        else if(transform.position.x < -22)
        {
            _direction = transform.right;
            sprite.flipX = false;
        }
    }
}
