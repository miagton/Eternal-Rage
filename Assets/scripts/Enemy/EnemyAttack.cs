using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    Transform player;
    public Transform attackPlace;
    public float attackRange = 0.5f;
    public LayerMask EnemiesToHit;
    public float Damage = 0.1f;
    public Animator anim;
   // Rigidbody2D rigidbody2D;


    [SerializeField]
    float _TimeBetwAttack;
    float StartTimeBetwAttack = 2f;

    private void Start()
    {
        player = GameObject.Find("Character").GetComponent<Transform>();
       // rigidbody2D = gameObject.GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        AttackTimer();
       
       
       
       if (Vector3.Distance(transform.position,player.position ) < 1.5f) 
        { 
        Attack();
       // AttackTimer();
        }
  
    }

    void Attack()
    {
        if (_TimeBetwAttack <= 0)
        {
            
            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(attackPlace.position, attackRange, EnemiesToHit);
            
               
                anim.SetTrigger("Attack");
                foreach (Collider2D enemy in HitEnemies)
                {
                  if (enemy.gameObject.tag == ("Player"))
                  {
                    enemy.GetComponent<Character>().TakeDamage(Damage);
               
                  }
                 // Debug.Log("enemy Name :" + enemy.name);
                }
                _TimeBetwAttack = StartTimeBetwAttack;

           
           
        }
    }

   
    void AttackTimer()
    {
        _TimeBetwAttack -= Time.deltaTime;
        if (_TimeBetwAttack < 0)
        {
            _TimeBetwAttack = 0;
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPlace == null)
        {
            return;
        }
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPlace.position, attackRange);
    }


}
