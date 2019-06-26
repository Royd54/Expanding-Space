using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject loadingCam;
    private GameObject spawnRoom;
    private PlayButton levelLoader;
    [SerializeField] private GameObject player;

    private void Start()
    {
        levelLoader = GameObject.FindWithTag("ButtonHendler").GetComponent<PlayButton>();
        loadingCam = this.transform.parent.transform.parent.gameObject;
        spawnRoom = GameObject.FindWithTag("Rooms");
    }

    private void DoneLoading()
    {
        Destroy(loadingCam);
        player.SetActive(true);
    }

    private void LoadingFailed()
    {
        levelLoader.LoadLevelByName("Generator");
    }
}
