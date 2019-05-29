using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomSpawner : MonoBehaviour
{
    private enum SpawnDir
    {
        left,
        right,
        top,
        bottom
    }
    [SerializeField] private SpawnDir sd = SpawnDir.left;
    private RoomSpawner rs;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        rs = GameObject.FindWithTag("Rooms").GetComponent<RoomSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Spawn", 1f);
    }

    private void Spawn()
    {
        if(!spawned)
        {

        }
    }
}
