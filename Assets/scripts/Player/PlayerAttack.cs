using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
   // public Animator animator;
    public Transform attackPlace;
    public float attackRange = 0.5f;
    public LayerMask EnemiesToHit;
    public int Damage;
    public Animator anim;

    [SerializeField]
     float _TimeBetwAttack;
     float StartTimeBetwAttack = 0.8f;


    // Update is called once per frame
    void Update()
    {
        AttackTimer();
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Attack();
        }
    }

    void Attack()
    {
        if (_TimeBetwAttack <= 0)
        {
            anim.SetTrigger("Attack");
            AudioManager.PlaySound("sword");
            Collider2D[] HitEnemies = Physics2D.OverlapCircleAll(attackPlace.position, attackRange, EnemiesToHit);
            foreach (Collider2D enemy in HitEnemies)
            {
                if (enemy.gameObject.tag == ("Enemy"))
                {
                    enemy.GetComponent<EnemieController>().TakeDamage(Damage);
                }
              //  else if (enemy.gameObject.tag == ("FlyingEnemie"))
               // {
               //     enemy.GetComponent<FlyingEnemy>().TakeDamage(Damage);
               // }
                else if (enemy.gameObject.tag == ("Boss"))
                {
                    enemy.GetComponent<FLyingBoss>().TakeDamage(Damage);
                }
                    
               
                // Debug.Log("enemy Name :" + enemy.name);
            }
            _TimeBetwAttack = StartTimeBetwAttack;
        }
       /* else
        {
            _TimeBetwAttack -= Time.deltaTime;
        }*/
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

    void AttackTimer()
    {
        _TimeBetwAttack -= Time.deltaTime;
        if(_TimeBetwAttack < 0)
        {
            _TimeBetwAttack = 0;
        }
    }

}
