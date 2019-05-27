using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnHandeler : MonoBehaviour
{
    [SerializeField] private List<GameObject> rooms = new List<GameObject>();
    [SerializeField] private List<GameObject> spawners = new List<GameObject>();

    private void Start()
    {
        Instantiate(rooms[Random.Range(0, rooms.Capacity)], this.transform.position, this.transform.rotation);
        foreach (GameObject spawner in GameObject.FindGameObjectsWithTag("RoomSpawner"))
            spawners.Add(spawner);
        
    }

    private void Update()
    {
        Debug.Log(spawners.Capacity);
        Invoke("SpawnRoom", 1f);
    }

    private void SpawnRoom()
    {
        //Instantiate(rooms[Random.Range(0, rooms.Capacity)], )
    }
}
