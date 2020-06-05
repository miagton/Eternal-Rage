using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemieSpwner : MonoBehaviour
{
    public GameObject EnemieToSpwn1;
    public GameObject EnemieToSpwn2;
    //public GameObject EnemieToSpwn3;
    float SpwnTimer;
    public float SpwnExists;
    
    
    // Start is called before the first frame update
   

    private void OnEnable()
    {
        SpwnTimer = Random.Range(3, 7);
        StartCoroutine(Spwner());
    }

    IEnumerator Spwner()
    {
        while (true)
        {
            yield return new WaitForSeconds(SpwnTimer);

            // Instantiate(EnemieToSpwn1, transform.position, Quaternion.identity);
            EnemyChoose();
            SpwnExists += 5;
            if(SpwnExists>= 800)
            {
                break;
            }
        }
       
    }

    private void EnemyChoose()
    {
        int R = Random.Range(1, 5);
        if (R >= 1 && R <=3)
        {
            Instantiate(EnemieToSpwn2, transform.position, Quaternion.identity);
        }
        else if (R == 4)
        {
            Instantiate(EnemieToSpwn1, transform.position, Quaternion.identity);
        }
    }
}
