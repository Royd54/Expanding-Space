using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField]private AudioClip hoverFX;

    private void Start()
    {
        audioS = GameObject.Find("audioHandler").GetComponent<AudioSource>();
    }

    public void playSound()
    {
        audioS.PlayOneShot(hoverFX);
    }

    public void PlayGame()
    {
        LoadLevelByIndex(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Retry()
    {
        LoadAsynchronouslyByName("PlaytestOverworld");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void MainMenu()
    {
        LoadAsynchronouslyByName("Main Menu");
    }

    public void LoadLevelByIndex(int sceneIndex)
    {
        Debug.Log("hi");
        StartCoroutine(LoadAsynchronouslyByIndex(sceneIndex));
    }
    public void LoadLevelByName(string sceneName)
    {
        StartCoroutine(LoadAsynchronouslyByName(sceneName));
    }

    IEnumerator LoadAsynchronouslyByIndex(int sceneIndex)
    {
        Debug.Log("hey");
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }
    IEnumerator LoadAsynchronouslyByName(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            Debug.Log(operation.progress);

            yield return null;
        }
    }

}
