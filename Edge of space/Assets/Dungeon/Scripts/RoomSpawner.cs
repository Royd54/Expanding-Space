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
    private SpawnRoom rooms;
    private bool spawned = false;

    // Start is called before the first frame update
    void Start()
    {
        rooms = GameObject.FindWithTag("Rooms").GetComponent<SpawnRoom>();
    }

    // Update is called once per frame
    void Update()
    {
        Invoke("Spawn", 0.6f);
    }

    private void Spawn()
    {
        if(!spawned)
        {
            if (sd == SpawnDir.top)
            {
                int rnd = Random.Range(0, rooms.hallwayTopEntrys.Length);
                Instantiate(rooms.hallwayTopEntrys[rnd], this.transform.position, this.transform.rotation);
            }
            if (sd == SpawnDir.left)
            {
                int rnd = Random.Range(0, rooms.hallwayLeftEntrys.Length);
                Instantiate(rooms.hallwayLeftEntrys[rnd], this.transform.position, this.transform.rotation);
            }
            if (sd == SpawnDir.bottom)
            {
                int rnd = Random.Range(0, rooms.hallwayBottomEntrys.Length);
                Instantiate(rooms.hallwayBottomEntrys[rnd], this.transform.position, this.transform.rotation);
            }
            if (sd == SpawnDir.right)
            {
                int rnd = Random.Range(0, rooms.hallwayRightEntrys.Length);
                Instantiate(rooms.hallwayRightEntrys[rnd], this.transform.position, this.transform.rotation);
            }
            spawned = true;
        }
    }
}
