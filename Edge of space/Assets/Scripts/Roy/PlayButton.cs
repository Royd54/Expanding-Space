using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField] private AudioClip hoverFX;
    [SerializeField] private GameObject loadingScrene;
    private GameObject loadingBar;
    private GameObject menu;

    private void Start()
    {
        audioS = GameObject.Find("audioHandler").GetComponent<AudioSource>();
        loadingBar = GameObject.FindWithTag("bar");
        menu = GameObject.FindWithTag("Menu");
        loadingScrene.SetActive(false);
    }

    public void playSound()
    {
        audioS.PlayOneShot(hoverFX);
    }

    public void PlayGame()
    {
        LoadLevelByName("BeginScene");
    }

    public void Retry()
    {
        Debug.Log("load2");
        LoadLevelByName("PlaytestOverworld");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Exit");
    }

    public void MainMenu()
    {
        LoadLevelByName("Main Menu");
    }
    
    public void LoadLevelByName(string sceneName)
    {
        try
        {
            menu.SetActive(false);
        }
        catch
        {
            //do nothing
        }
        loadingScrene.SetActive(true);
        StartCoroutine(LoadAsynchronouslyByName(sceneName));
    }
    IEnumerator LoadAsynchronouslyByName(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);

            loadingBar.GetComponent<Image>().fillAmount = progress;
            yield return null;
        }
    }

}
