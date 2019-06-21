using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public void LoadLevelByIndex (int sceneIndex)
    {
        StartCoroutine(LoadAsynchronouslyByIndex(sceneIndex));
    }
    public void LoadLevelByName (string sceneName)
    {
        StartCoroutine(LoadAsynchronouslyByName(sceneName));
    }

    IEnumerator LoadAsynchronouslyByIndex (int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while(!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
    IEnumerator LoadAsynchronouslyByName (string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while(!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
}
