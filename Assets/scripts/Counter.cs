using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Counter : MonoBehaviour
{
    UIManager Ui;
    
    public int Killcount;
    public void OnEnable()
    {
        GameObject.Find("UImanager").GetComponent<UIManager>().Score++;
       
        Ui = GameObject.Find("UImanager").GetComponent<UIManager>();
        Ui.NewScore();
    }

    void Start()
    {
               
       
    }
    private void Update()
    {
       

    }

}
