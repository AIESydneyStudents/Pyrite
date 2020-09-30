using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Loads the next scene
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;

    public List<string> scenes = new List<string>();
    public int currentScene = 0;

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadNextScene()
    {
        var sceneIndex = SceneManager.GetSceneByName(scenes[currentScene]).buildIndex+1;
        
        StartCoroutine(LoadScene(sceneIndex));
        currentScene += 1;
        
        if (currentScene == scenes.Count)
            currentScene = 0;
    }

    IEnumerator LoadScene(int sceneIndex)
    {
        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(sceneIndex);
    }
}
