using System.Collections;
using System.Collections.Generic;
using System.Numerics;

using UnityEngine;

public class Attack : MonoBehaviour
{
    Transform transform;
     float _TimeBetwAttack;
    public float StartTimeBetwAttack;

    public Transform AttackPos;
    public float AttacktRange;

    public LayerMask WhatIsEnemy;

    public int Damage;

    
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Swing();
        OnDrawGizmosSelected();
    }
    public void Swing()
    {
        if(_TimeBetwAttack<= 0)//then we can attack
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Collider2D[] EnemiesToDamage = Physics2D.OverlapCircleAll(AttackPos.position, AttacktRange,WhatIsEnemy);
                for (int i = 0; i < EnemiesToDamage.Length; i++)
                {
                    EnemiesToDamage[i].GetComponent<EnemieController>().TakeDamage(Damage);
                    Debug.Log(EnemiesToDamage[i]);
                }
                
            }

            _TimeBetwAttack = StartTimeBetwAttack;
        }
        else
        {
            _TimeBetwAttack -= Time.deltaTime;//if not starting timer tor decrease
        }
        
        
        
     
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(AttackPos.position, AttacktRange);
    }
}


