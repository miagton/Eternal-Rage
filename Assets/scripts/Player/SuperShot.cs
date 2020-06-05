using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperShot : MonoBehaviour
{
    public ParticleSystem Charge;
    public Animator animator;

    float SkillCd = 15;
    float SkillTimer = 0;
    bool isCharging;

    Transform checkSide;

    private RaycastHit2D hit;
    private Ray ray;
    private float rayDistance = 50;
    void Start()
    {
        checkSide = GameObject.Find("AttackPos").transform;
    }


    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            isCharging = true;
            if (SkillTimer <= 0 && isCharging == true)
            {
                Instantiate(Charge, transform.position, Quaternion.identity);
               // ray = new Ray(transform.position, transform.right);
                hit = Physics2D.Raycast(checkSide.position+transform.up * 0.6f, checkSide.right*rayDistance);
                Debug.DrawRay(ray.origin +transform.up*0.6f, ray.direction * rayDistance, Color.red);
                if (hit)
                {
                    Debug.Log(hit.transform);
                    EnemieController enemy = hit.transform.GetComponent<EnemieController>();
                    if (enemy != null)
                    {
                        enemy.TakeDamage(100);
                    }
                }
            }

        }
        else if (Input.GetKeyUp(KeyCode.Q))
        {
            Charge.IsAlive(false);
            isCharging = false;
        }
    }


}
