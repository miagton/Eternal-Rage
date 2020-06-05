using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text KillInfo;
    public Text Arrows;

    public   int Score;
    

    private void Start()
    {
        
    }
   
    public void NewScore()
    {
        KillInfo.text =( "Score :" + Score);
    }
    public void AmmoDisplay(int ammo)
    {
        Arrows.text = "x" + ammo;
    }
}
