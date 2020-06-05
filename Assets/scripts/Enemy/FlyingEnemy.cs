using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{ 
 public float Speed;
 public ParticleSystem BOOM;

Rigidbody2D _rigidbody2D;

public Transform StrikePoint;



Vector3 PlayerPos;
Transform Player;


public Animator Animator;

    int score;
 int MaxHealth = 1;
 int _CurrentHealth;
 float Damage = 0.3f;

Vector3 newPosition;






// Start is called before the first frame update
void Start()
{
    _rigidbody2D = GetComponent<Rigidbody2D>();
  //  _direction = transform.right;

    _CurrentHealth = MaxHealth;

        score = GameObject.Find("UImanager").GetComponent<UIManager>().Score;
        //PlayerFound();

    }



private void Awake()
{
    Player = GameObject.Find("Character").transform;
}


void Update()
{
    //   OnDrawGizmosSelected();

    Run();
   
    Die();

}


void Run()
{
    

    SetTransformX(0);

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


private void OnDrawGizmosSelected()
{
    Gizmos.color = Color.red;
    Gizmos.DrawWireSphere(transform.position + transform.up * -0.8F + transform.right * -0.5F, 0.1F);
}

void SetTransformX(float n)
{
    // Vector3 newposition;
    newPosition = new Vector3(Player.position.x, Player.position.y, n);
    // newposition = new Vector3(PlayerPos.position.x, transform.position.y, PlayerPos.position.z*n);
}
void Die()
{

        UIManager Ui;     
        if (_CurrentHealth <= 0)
    {
            //Add die animation
            //disable object
            // Animator.SetTrigger("Die");
            GameObject.Find("UImanager").GetComponent<UIManager>().Score++;
            Ui = GameObject.Find("UImanager").GetComponent<UIManager>();
            Ui.NewScore();
            Instantiate(BOOM, transform.position, Quaternion.identity);
            Destroy(gameObject);
       // Instantiate(DeadBody, transform.position, transform.rotation);
    }
}

public void TakeDamage(int damage)
{
    Animator.SetTrigger("Hit");
    _CurrentHealth -= damage;
    if (StrikePoint.position.x < transform.position.x)
    {
        _rigidbody2D.velocity = new Vector2(2, 2);
    }
    else if (StrikePoint.position.x > transform.position.x)
    {
        _rigidbody2D.velocity = new Vector2(-2, 1);
    }



    //add damage animation
    if (_CurrentHealth <= 0)
    {

        Die();
    }

    Debug.Log(_CurrentHealth);
}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.GetComponent<Character>().TakeDamage(Damage);

            Instantiate(BOOM, transform.position, Quaternion.identity); 
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Dodge")
        {
            Destroy(this.gameObject);
        }
    }
}

