using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoPickUp : MonoBehaviour
{


    public ParticleSystem BOOM;

    private void Start()
    {
        Destroy(gameObject, 3);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        
        if (collision.gameObject.tag == ("Player"))
        {
            if (collision.GetComponent<Shooting>().AmmoCount < 10)
            {
                collision.GetComponent<Shooting>().AmmoCount++;
                Instantiate(BOOM, transform.position,Quaternion.identity);
               
                Destroy(gameObject);
            }
        }
    }


}
