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

    public string previousScene;
    public string currentScene;
    public string nextScene;
    public string mainMenu;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(playFirstButton);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadPreviousScene()
    {
        StartCoroutine(LoadScene(previousScene));
    }

    public void LoadCurrentScene()
    {
        StartCoroutine(LoadScene(currentScene));
    }

    public void LoadNextScene()
    {
        StartCoroutine(LoadScene(nextScene));
    }

    public void LoadMainMenu()
    {
        StartCoroutine(LoadScene(mainMenu));
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
}
