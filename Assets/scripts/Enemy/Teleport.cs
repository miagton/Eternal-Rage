using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    Vector3 playerPos;
    void Start()
    {
        playerPos = GameObject.Find("Character").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = GameObject.Find("Character").transform.position;
        if (Vector3.Distance(transform.position,playerPos)> 17)
        {
            transform.position = playerPos;
        }
    }
}
