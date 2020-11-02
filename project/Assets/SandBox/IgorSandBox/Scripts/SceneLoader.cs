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

    public PlayerData data;

    public string splashScene;
    public string tutorialScene;
    public string Level_01;
    public string mainMenu;
    public string gameOverScene;
    public string optionsScene;
    public string creditsScene;

    private GameMaster gameMaster;


    private void Start()
    {
        if (SaveLoad.SaveExists("PlayerData"))
            data = SaveLoad.Load<PlayerData>("PlayerData");

        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(playFirstButton);

        if (SceneManager.GetActiveScene().name == splashScene)
        {
            StartCoroutine(LoadFromSplashScene(mainMenu));
        }
        gameMaster = GameObject.FindGameObjectWithTag("GameMaster").GetComponent<GameMaster>();
    }

    public void LoadSplashScene()
    {
        StartCoroutine(LoadScene(splashScene));
    }

    public void LoadTutorialScene()
    {
        SaveLoad.SeriouslyDeleteAllSaveFiles();
        gameMaster.playerLives = 3;
        StartCoroutine(LoadScene(tutorialScene));
    }

    public void LoadlevelOneScene()
    {
        StartCoroutine(LoadScene(Level_01));
    }

    public void LoadContinueScene()
    {
        Debug.Log(gameMaster.savedScene);
        StartCoroutine(LoadScene(gameMaster.savedScene));
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
        if(SceneManager.GetActiveScene().name == Level_01 || SceneManager.GetActiveScene().name == tutorialScene)
            yield return new WaitForSeconds(4);

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
