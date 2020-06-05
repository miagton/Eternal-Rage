using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            
            Debug.Log(Time.timeScale);
            if (GameIsPaused!= true)
            {
                Pause();
            }
            else
            {
                Resume();
            }

        }
    }
  public  void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1;
        GameIsPaused = false;
    }
    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0;//stops tiem in game
        GameIsPaused = true;
    }
    public void LoadMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }
    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }
}
