using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// Handles the main menu
/// </summary>
public class MainMenu : MonoBehaviour
{
    //public string newGameScene;

    public GameObject playFirstButton;

    //public GameObject button;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(playFirstButton);
    }

    private void Update()
    {

    }
    public void PlayGame()
    {
        FindObjectOfType<SceneLoader>().LoadNextScene();
        //SceneManager.LoadScene(newGameScene);
    }

    //public void GoToMenu()
    //{
    //    FindObjectOfType<SceneLoader>().LoadNextScene();
    //}

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
