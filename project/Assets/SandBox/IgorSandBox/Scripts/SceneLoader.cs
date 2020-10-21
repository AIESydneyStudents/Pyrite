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

    public string splashScene;
    public string tutorialScene;
    public string levelOneScene;
    public string mainMenu;
    public string gameOverScene;
    public string optionsScene;
    public string creditsScene;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(playFirstButton);

        if(SceneManager.GetActiveScene().name == splashScene )
        {
            StartCoroutine(LoadFromSplashScene(levelOneScene));
        }
    }

   

    public void LoadSplashScene()
    {
        StartCoroutine(LoadScene(splashScene));
    }

    public void LoadTutorialScene()
    {
        StartCoroutine(LoadScene(tutorialScene));
    }

    public void LoadlevelOneScene()
    {
        StartCoroutine(LoadScene(levelOneScene));
        Debug.Log("level1");
    }

    public void LoadContinueScene()
    {
        StartCoroutine(LoadScene(levelOneScene));
       
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
    //public void LoadNextScene()
    //{
    //    var sceneIndex = SceneManager.GetSceneByName(scenes[currentScene]).buildIndex;

    //    StartCoroutine(LoadScene(sceneIndex));
    //    currentScene += 1;

    //    if (currentScene == scenes.Count)
    //        currentScene = 0;
    //}

    IEnumerator LoadScene(string scene)
    {
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
