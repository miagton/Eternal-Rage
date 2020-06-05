using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScreen : MonoBehaviour
{
    public GameObject DeathScene;
    public GameObject Character;

    // Update is called once per frame
    void Update()
    {
        if(Character == false)
        {
            Time.timeScale = 0.2f;
            DeathScene.SetActive(true);
        }
        else if(Character == true)
        {
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
