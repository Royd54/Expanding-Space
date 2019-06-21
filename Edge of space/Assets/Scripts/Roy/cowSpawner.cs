using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cowSpawner : MonoBehaviour
{
    [SerializeField] private Transform[] cowSpawnpoints;
    [SerializeField] private GameObject cow;
    private GameObject player;

    private void Start()
    {
        player = GameObject.Find("Player");
    }

    public void SpawnCow()
    {
            int SpawnPointIndex = Random.Range(0, cowSpawnpoints.Length);
            if (Vector2.Distance(cowSpawnpoints[SpawnPointIndex].position, player.transform.position) > 25)
            { 
            Instantiate(cow, cowSpawnpoints[SpawnPointIndex].position, cowSpawnpoints[SpawnPointIndex].rotation);
            }
            else
            {
                SpawnPointIndex++;
            }
    }

}
