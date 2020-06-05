using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingPotion : MonoBehaviour
{
    public ParticleSystem BOOM;
    GameObject Healthbar;

    private void Start()
    {
        Healthbar = GameObject.Find("HealthBar");

            Destroy(gameObject, 3);
      
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.tag == ("Player"))
        {
            if (collision.GetComponent<Character>().CurrentHealth<1)
            {
               
                collision.GetComponent<Character>().CurrentHealth+= 0.2f;
               var health = collision.GetComponent<Character>().CurrentHealth;
                Healthbar.GetComponent<HealthBarFade>().SetHealth(health);
                Instantiate(BOOM, transform.position, Quaternion.identity);

                Destroy(gameObject);
            }
        }
    }
}
