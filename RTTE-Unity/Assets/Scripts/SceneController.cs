using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneController
{
    public static void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    public static void LoadScene(Scene scene)
    {
        if (scene != null)
            SceneManager.LoadScene(scene.name);
    }

    public static void ReloadScene()
    {
        LoadScene(SceneManager.GetActiveScene());
    }
}
