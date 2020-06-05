using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class DestroyBelow : MonoBehaviour
{

    private void Update()
    {
        DestroyWhenFall();
    }

    public void DestroyWhenFall()
    {
       
        if( (0 + transform.position.y) < -13)
        {
            Destroy(this.gameObject);
        }
    }
  
}
