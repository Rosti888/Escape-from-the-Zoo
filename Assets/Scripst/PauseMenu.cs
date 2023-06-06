using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public GameObject audioChecker;

    public SquirrelMovement Squirrel;
    public BeaverMovement Beaver;
    public BoarMovement Boar;

    public CharacterSwitch characterSwitch;

    public Button pauseButton;
    public Button restartButton;

    public bool isPaused;

    private void Start()
    {
        pauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else if(!isPaused)
            {
                PauseGame();
            }
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (!isPaused)
            {
                RestartLevel();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.enabled = false;
        Squirrel.enabled = false;
        Beaver.enabled = false;
        Boar.enabled = false;
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        pauseButton.enabled = true;

        if (characterSwitch.currentIndex == 0)
        {
            Squirrel.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Squirrel.enabled = true;
            Beaver.enabled = false;
            Boar.enabled = false;
        }

        if (characterSwitch.currentIndex == 1)
        {
            Beaver.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Squirrel.enabled = false;
            Beaver.enabled = true;
            Boar.enabled = false;
        }

        if (characterSwitch.currentIndex == 2)
        {
            Boar.rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
            Squirrel.enabled = false;
            Beaver.enabled = false;
            Boar.enabled = true;
        }
    }

    public void GoToMainMenu()
    { 
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void RestartLevel()
    {
        characterSwitch.StartLevel();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
