using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
  //  private AudioClip background;
    
    private void Start()
    {
       // background = Resources.Load<AudioClip>("Background1");
        AudioManager.PlaySound("background1");
    }
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);//GEting Indext of Current Scene and increasing it by 1 (Loading NExt)
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
