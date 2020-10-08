using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;

/// <summary>
/// Controls the pause menu.
/// </summary>
public class PauseMenu : MonoBehaviour
{
    public string mainMenuScene;

    public bool gameIsPaused = false;

    public GameObject pauseMenuUI;

    public GameObject pauseFirstButton;

    public Controls controls;


    private void Start()
    {

        gameIsPaused = false;
        controls = new Controls();
        controls.Enable();
        controls.Player.Pause.performed += Pause_performed;

    }

    private void Pause_performed(InputAction.CallbackContext obj)
    {

        if (gameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        }
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(pauseFirstButton);



        Time.timeScale = 0.0f;
        gameIsPaused = true;


    }

    public void Resume()
    {

        pauseMenuUI.SetActive(false);


        Time.timeScale = 1.0f;
        gameIsPaused = false;
    }

    public void LoadMenu()
    {
        Debug.Log("Loading Menu...");
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(mainMenuScene);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting Game...");
        Application.Quit();
    }
}
