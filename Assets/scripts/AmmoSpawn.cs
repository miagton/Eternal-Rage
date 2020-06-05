using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoSpawn : MonoBehaviour
{
    public GameObject Ammo;

    Vector3 PositionToSpawn;
    
    void Start()
    {
        PositionToSpawn = new Vector3(transform.position.x, transform.position.y + 0.3f, transform.position.z);

        Instantiate(Ammo, PositionToSpawn, Quaternion.identity);
        
    }

    
}
