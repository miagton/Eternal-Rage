


using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rigidbody2D;
    public float speed = 10f;
    public int Damage = 5;
    Vector2 NewForce;
    // float direction;
    Transform Character;
    Transform ShootingSpot;
    SpriteRenderer sprite;



    // Start is called before the first frame update
    void Start()
    {
        Character = GameObject.Find("Character").transform;
        ShootingSpot = GameObject.Find("FirePoint").transform;
        sprite = GetComponent<SpriteRenderer>();


        rigidbody2D = GetComponent<Rigidbody2D>();

        if (ShootingSpot.position.x > Character.position.x)
        {
            NewForce = new Vector2(speed, 0);
            rigidbody2D.AddForce(NewForce, ForceMode2D.Impulse);
        }
        else if (ShootingSpot.position.x < Character.position.x)
        {
            NewForce = new Vector2(-speed, 0);
            rigidbody2D.AddForce(NewForce, ForceMode2D.Impulse);
            sprite.flipX = true;
        }

        Destroy(gameObject, 2f);



        // direction =Input.GetAxisRaw("Horizontal");

    }

    // Update is called once per frame
    void Update()
    {
        /*  if (ShootingSpot.position.x  > Character.position.x)
           {
               NewForce = new Vector2(speed, 0);
               rigidbody2D.AddForce(NewForce, ForceMode2D.Impulse);
           }
           else if (ShootingSpot.position.x < Character.position.x)
           {
               NewForce = new Vector2(-speed, 0);
               rigidbody2D.AddForce(NewForce, ForceMode2D.Impulse);
               sprite.flipX = true;
           }

           */



    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(collision.name);
        if (collision.gameObject.tag == ("Enemy"))
        {
            // Debug.Log("Ugot one!" + collision);
            collision.gameObject.GetComponent<EnemieController>().TakeDamage(Damage);

            Destroy(gameObject);
            
        }
        else if (collision.gameObject.tag == "FlyingEnemie")
        {
            collision.gameObject.GetComponent<FlyingEnemy>().TakeDamage(Damage);

            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Boss")
        {
            collision.gameObject.GetComponent<FLyingBoss>().TakeDamage(Damage);
            Destroy(gameObject);
        }
    }
}

