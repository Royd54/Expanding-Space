using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    private GameObject loadingCam;
    private GameObject spawnRoom;
    [SerializeField] private GameObject player;

    private void Start()
    {
        loadingCam = this.transform.parent.transform.parent.gameObject;
        spawnRoom = GameObject.FindWithTag("Rooms");
    }

    private void DoneLoading()
    {
        Destroy(loadingCam);
        Instantiate(player, spawnRoom.transform.position, spawnRoom.transform.rotation);
    }
}
