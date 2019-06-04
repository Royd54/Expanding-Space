using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemys;
    private SpawnRoom rooms;
    private bool spawned = false;

    void Start()
    {
        rooms = GameObject.FindWithTag("Rooms").GetComponent<SpawnRoom>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rooms.GetGenTime() <= 0f && !spawned)
        {
            if (Vector2.Distance(GameObject.FindWithTag("Player").transform.position, this.transform.position) < 10f)
            {
                Instantiate(enemys[Random.Range(0, enemys.Length)], this.transform.position, this.transform.rotation);
                spawned = true;
            }
        }
            
    }
}
