using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    public Animator animator;

    float RollTimer = 0.6f;
    [SerializeField]
    float RollingTime;
   [SerializeField]
    bool IsRolling;
    Transform CheckSide;
    public float RollPower = 10f;

    Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        CheckSide = GameObject.Find("AttackPos").transform;
       // StartCoroutine("LayerChange");
    }
    private void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
        {
            DashRoll();
        }
        Timer();
       
    }
    void DashRoll()
    {
        // Vector3 Newposition1 = new Vector3( RollPower*5, 0, 0);
        // Vector3 Newposition2 = new Vector3( -RollPower*5, 0, 0);

        if (RollingTime <= 0)
        {
           // gameObject.layer = LayerMask.NameToLayer("Character");
            //gameObject.GetComponent<Collider2D>().enabled = true;
            if ( IsRolling == false)
            {
                // gameObject.GetComponent<Collider2D>().enabled = false;
                if (CheckSide.position.x > transform.position.x)
                {
                    gameObject.layer = LayerMask.NameToLayer("Dodge");
                    // GetComponent<Collider2D>().enabled = false;
                    _rigidbody2D.velocity = new Vector3(RollPower, 0.5f, 0);
                    //Vector3 direction = transform.right * RollPower;
                    //  transform.position = Vector3.MoveTowards(transform.position,transform.position + direction, Speed *Time.deltaTime);
                    // _rigidbody2D.AddForce(Newposition1, ForceMode2D.Impulse);
                    animator.SetTrigger("Dash");
                    IsRolling = true;
                    RollingTime = RollTimer;


                }
                else if (CheckSide.position.x < transform.position.x)
                {
                    gameObject.layer = LayerMask.NameToLayer("Dodge");
                    // GetComponent<Collider2D>().enabled = false;
                    //Vector3 direction = -transform.right * RollPower;
                    // transform.position = Vector3.MoveTowards(transform.position,transform.position + direction, Speed * Time.deltaTime);
                    _rigidbody2D.velocity = new Vector3(-RollPower, 0.5f, 0);
                    // _rigidbody2D.AddForce(Newposition2, ForceMode2D.Impulse);
                    animator.SetTrigger("Dash");
                    IsRolling = true;
                    RollingTime = RollTimer;

                }


            }
        }
        else if (RollingTime > 0 && RollingTime <= RollTimer)
        {
           // gameObject.layer = LayerMask.NameToLayer("Dodge");
            // gameObject.GetComponent<Collider2D>().enabled = false;
           // RollingTime -= Time.deltaTime;
            IsRolling = false;
        }
        else
        {

            gameObject.layer = LayerMask.NameToLayer("Character");
            // gameObject.GetComponent<Collider2D>().enabled = true;
           // RollingTime -= Time.deltaTime;
            IsRolling = false;

        }
    }

    void Timer()
    {
        RollingTime -= Time.deltaTime;
        if (RollingTime <= 0.2f)
        {
            IsRolling = false;
            gameObject.layer = LayerMask.NameToLayer("Character");
            // RollingTime = 0;
        }
        else if(RollingTime <= 0)
        {
            // RollingTime = 0;
        }
    }

    IEnumerator LayerChange()
    {
        gameObject.layer = LayerMask.NameToLayer("Character");
        yield return new WaitForSeconds(1);

    }

}
