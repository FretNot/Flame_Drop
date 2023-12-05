using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [SerializeField]
    GameObject pauseMenu;
    [SerializeField]
    GameObject instructionsMenu;
   public void PlayGame()
    {
        SceneManager.LoadScene("Blockout");
    }

    public void GoToMainMenu()
    {
        SceneManager.LoadScene("StartScreen");
        Time.timeScale = 1;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void Retrygame()
    {
        SceneManager.LoadScene("Blockout");
        Time.timeScale = 1;
    }

    public void gameInstructions()
    {
        SceneManager.LoadScene("Instructions");
        Time.timeScale = 1;
    }

    public void pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void pauseInstructions()
    {
        pauseMenu.SetActive(true);
        instructionsMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void resume()
    {
        pauseMenu.SetActive(false);
        instructionsMenu.SetActive(false);
        Time.timeScale = 1;
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

}
