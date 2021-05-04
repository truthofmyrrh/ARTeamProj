using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    string lastScene;
    string currentScene;
    // Start is called before the first frame update
    public void ChangeSscene(string sceneName)
    {
        currentScene = SceneManager.GetActiveScene().name;
        previousScenes.Push(currentScene);
        Debug.Log("pushed " + currentScene);
        SceneManager.LoadScene(sceneName);
    }

    public Stack<string> previousScenes;

    private void Start()
    {
        previousScenes = new Stack<string>();
        Debug.Log("stack created");
    }
    public void BackToPrevioousScene()
    {
        string lastScene = previousScenes.Pop();
        Debug.Log("popped : " + lastScene);
        SceneManager.LoadScene(lastScene);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
