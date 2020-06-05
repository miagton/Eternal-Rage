using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    float speed = 6 ;
    //public ParticleSystem BOOM;

   // Rigidbody2D _rigidbody2D;
    
     Transform Player;
       // public Animator Animator;


   
    float Damage = 0.3f;

    

    private void Awake()
    {
        Player = GameObject.Find("Character").transform;
    }

    void Start()
    {
       // _rigidbody2D = GetComponent<Rigidbody2D>();
        

        Destroy(this.gameObject, 3f);
    }

    
    void Update()
    {
        Run();
        
    }

    void Run()
    {
              

        transform.position = Vector3.MoveTowards(transform.position,Player.position, speed * Time.deltaTime);

      /*  if ((Player.position.x - transform.position.x) > 0)
        {
            transform.eulerAngles = new Vector3(0, 180, 0);
        }
        else if ((Player.position.x - transform.position.x) < 0)
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
        }*/
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Character>().TakeDamage(Damage);

            //Instantiate(BOOM, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
        else if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "Boss")
      {
            Destroy(this.gameObject);
       }
    }


}
