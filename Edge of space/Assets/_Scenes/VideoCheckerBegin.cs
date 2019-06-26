using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VideoCheckerBegin : MonoBehaviour
{
    public GameObject VP;
    [SerializeField] private GameObject loadingScrene;
    private GameObject loadingBar;
    public GameObject VictoryUI;

    private void Start()
    {
        VP = GameObject.Find("Intro");
        VP.GetComponent<VideoPlayer>().loopPointReached += EndReached;
        loadingBar = GameObject.FindWithTag("bar");
        loadingScrene.SetActive(false);
        if (SceneManager.GetActiveScene().name == "EndingScene")
        {
            StartCoroutine(Victory());
        }
        
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        vp.playbackSpeed = vp.playbackSpeed / 10.0F;
        if (SceneManager.GetActiveScene().name == "BeginScene")
        {
            LoadLevelByName("PlaytestOverworld");
        }
    }

    public void LoadLevelByName(string sceneName)
    {
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

    IEnumerator Victory()
    {
        yield return new WaitForSeconds(24);
        VictoryUI.SetActive(true);
        VP.GetComponent<VideoPlayer>().Pause();
        
    }
}
