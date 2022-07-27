using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public void LoadScene(Scene scene)
    {
        if (scene != null)
            SceneManager.LoadScene(scene.name);
    }

    public void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene());
    }
}
