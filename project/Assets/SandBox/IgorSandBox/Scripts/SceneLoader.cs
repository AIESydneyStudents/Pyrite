using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

/// <summary>
/// Loads the next scene
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    // public List<string> scenes = new List<string>();
    //public int currentScene = 0;

    public GameObject playFirstButton;

    public PlayerData playerData;

    public string splashScene;
    public string tutorialScene;
    public string Level_01;
    public string mainMenu;
    public string gameOverScene;
    public string optionsScene;
    public string creditsScene;

    public GameEvent saveEvent;
    public GameEvent loadEvent;



    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(playFirstButton);

        if (SceneManager.GetActiveScene().name == splashScene)
        {
            StartCoroutine(LoadFromSplashScene(mainMenu));
        }
    }

    public void LoadSplashScene()
    {
        StartCoroutine(LoadScene(splashScene));
    }

    public void LoadTutorialScene()
    {
        playerData.PlayerLives = 3;
        playerData.hasCheckpoint = false;
        playerData.canDash = false;
        playerData.canDoubleJump = false;
        playerData.canGrapple = false;
        playerData.canGroundSlam = false;
        playerData.canWallJump = false;
        playerData.jumpImg = false;
        playerData.swingImg = false;
        playerData.dashImg = false;
        playerData.savedScene = "Tutorial";
        saveEvent.Raise();

        StartCoroutine(LoadScene(tutorialScene));
    }

    public void LoadlevelOneScene()
    {
        StartCoroutine(LoadScene(Level_01));
    }

    public void LoadContinueScene()
    {
        StartCoroutine(LoadScene(playerData.savedScene));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadScene(mainMenu));
    }

    public void LoadGameOverScene()
    {
        StartCoroutine(LoadScene(gameOverScene));
    }

    public void LoadOptionsScene()
    {
        StartCoroutine(LoadScene(optionsScene));
    }

    public void LoadCreditsScene()
    {
        StartCoroutine(LoadScene(creditsScene));
    }

    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }


    IEnumerator LoadScene(string scene)
    {
        if (SceneManager.GetActiveScene().name == Level_01 || SceneManager.GetActiveScene().name == tutorialScene)
            yield return new WaitForSeconds(0);

        if (SceneManager.GetActiveScene().name == mainMenu)
            yield return new WaitForSeconds(2.8f);


        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(scene);
    }

    IEnumerator LoadFromSplashScene(string scene)
    {
        yield return new WaitForSeconds(transitionTime);

        transition.SetTrigger("Start");

        SceneManager.LoadScene(scene);
    }
}
