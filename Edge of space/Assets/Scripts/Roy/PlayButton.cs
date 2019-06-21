﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    private AudioSource audioS;
    [SerializeField]private AudioClip hoverFX;
    private GameObject loadingScrene;
    private GameObject loadingBar;
    private GameObject menu;

    private void Start()
    {
        audioS = GameObject.Find("audioHandler").GetComponent<AudioSource>();
        loadingScrene = GameObject.FindWithTag("LoadingScrene");
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
        LoadLevelByName("PlaytestOverworld");
    }

    public void Retry()
    {
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
        StartCoroutine(LoadAsynchronouslyByName(sceneName));
        menu.SetActive(false);
        loadingScrene.SetActive(true);
    }
    IEnumerator LoadAsynchronouslyByName(string sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName);
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);
            
            yield return null;
        }
    }

}
