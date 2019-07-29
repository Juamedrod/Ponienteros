using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneHandler : MonoBehaviour
{    


    public void ToMainScene()
    {
        StartCoroutine(LoadSceneAsync("Ponienteros"));
    }

    IEnumerator LoadSceneAsync(string sceneName)
    {
        GameManager.gameManager.comingFromDiploWar = true;
        AsyncOperation async= SceneManager.LoadSceneAsync(sceneName);
        while (!async.isDone)
        {
            yield return null;

        }
    }


}
