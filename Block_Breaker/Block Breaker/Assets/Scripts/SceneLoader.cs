using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using namespace of SceneManagement
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
        Debug.Log("LoadNextScene from SceneLoader");
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<GameStatus>().RestartGame();
        Debug.Log("LoadStartScene from SceneLoader");
    }

    public void QuitGame()
    {
        Application.Quit();
    }


}
