using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    public SquirrelMovement Squirrel;
    public BeaverMovement Beaver;
    public BoarMovement Boar;

    public CharacterSwitch characterSwitch;

    public UnityEngine.UI.Button pauseButton;
    public UnityEngine.UI.Button restartButton;

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
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        pauseButton.enabled = false;
        restartButton.enabled = false;
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
        restartButton.enabled = true;

        if (characterSwitch.currentIndex == 0)
        {
            Squirrel.enabled = true;
            Beaver.enabled = false;
            Boar.enabled = false;
        }

        if (characterSwitch.currentIndex == 1)
        {
            Squirrel.enabled = false;
            Beaver.enabled = true;
            Boar.enabled = false;
        }

        if (characterSwitch.currentIndex == 2)
        {
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
}
