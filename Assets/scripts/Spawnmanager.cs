using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Spawnmanager : MonoBehaviour
{
    [SerializeField]
    int score;
    public  GameObject Boss1;
    public GameObject Boss2;
    GameObject Spawners;
    GameObject Spawners1;
    
    void Start()
    {
       // score = GameObject.Find("UImanager").GetComponent<UIManager>().Score;
        Spawners = GameObject.Find("EnemySpawners");
        Spawners1 = GameObject.Find("EnemySpawners2");
        Spawners1.SetActive(false);
    }

   
    void Update()
    {
        score = GameObject.Find("UImanager").GetComponent<UIManager>().Score;
        Spawning();
    }
    private void Spawning()
    {
        UIManager Ui;
        if(score == 20)
        {
            Vector3 position = new Vector3(0, 4, 0);
            Ui = GameObject.Find("UImanager").GetComponent<UIManager>();
            GameObject.Find("UImanager").GetComponent<UIManager>().Score ++;
            Ui.NewScore();

            Instantiate(Boss1, position, Quaternion.identity);
            Spawners.SetActive(false);
        }
        else if (score == 50)
        {
            Vector3 position = new Vector3(8.2f, 3, 0);
            Ui = GameObject.Find("UImanager").GetComponent<UIManager>();
            GameObject.Find("UImanager").GetComponent<UIManager>().Score++;
            Ui.NewScore();

            Instantiate(Boss2, position, Quaternion.identity);
            Spawners.SetActive(false);
            Spawners1.SetActive(false);

        }
        else if (score >= 70)
        {
            Spawners.SetActive(true);
            Spawners1.SetActive(true);
        }

    }
}
