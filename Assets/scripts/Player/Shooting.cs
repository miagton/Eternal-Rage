using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public Transform FirePoint;
    public GameObject Projectile;
    SpriteRenderer sprite;
    Vector3 NewForce;
    public float speed = 10f;
    public Animator animator;

    public int AmmoCount = 10;

    UIManager Ui;


    float TimeBetweenShot;
    float StartTimeBetweenShot = 1.0f;
    bool IsShooting;


    private void OnEnable()
    {
        Ui = GameObject.Find("UImanager").GetComponent<UIManager>();
    }
    

    // Update is called once per frame
    void Update()
    {
        ShootTimer();
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            Shoot();
           
        }
        Ui.AmmoDisplay(AmmoCount);
    }

    void Shoot()
    {
        if (AmmoCount > 0 && TimeBetweenShot <= 0)
        {
            animator.SetTrigger("Shoot");
            AudioManager.PlaySound("bow");
            Instantiate(Projectile, FirePoint.position, Projectile.transform.rotation);
            AmmoCount--;
            TimeBetweenShot = StartTimeBetweenShot;
            
            Debug.Log(AmmoCount);
        }
       

    }

    void ShootTimer()
    {
        TimeBetweenShot -= Time.deltaTime;
        if(TimeBetweenShot < 0)
        {
            TimeBetweenShot = 0;
        }
    }
}

