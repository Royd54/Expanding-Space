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
        Invoke("Spawn", 0.2f);
    }

    private void Spawn()
    {
        if(!spawned)
        {
            if (sd == SpawnDir.top)
            {
                if (rooms.GetGenTime() <= 0f)
                {
                    Instantiate(rooms.topBlocker, this.transform.position, this.transform.rotation);
                }
                else
                {
                    if (Random.Range(1, 3) == 1)
                    {
                        int rnd = Random.Range(0, rooms.hallwayTopEntrys.Length);
                        Instantiate(rooms.hallwayTopEntrys[rnd], this.transform.position, this.transform.rotation);
                    }
                    else
                    {
                        int rnd = Random.Range(0, rooms.roomTopEntrys.Length);
                        Instantiate(rooms.roomTopEntrys[rnd], this.transform.position, this.transform.rotation);
                    }
                }
            }
            if (sd == SpawnDir.left)
            {
                if (rooms.GetGenTime() <= 0f)
                {
                    Instantiate(rooms.leftBlocker, this.transform.position, this.transform.rotation);
                }
                else
                {
                    if (Random.Range(1, 3) == 1)
                    {
                        int rnd = Random.Range(0, rooms.hallwayLeftEntrys.Length);
                        Instantiate(rooms.hallwayLeftEntrys[rnd], this.transform.position, this.transform.rotation);
                    }
                    else
                    {
                        int rnd = Random.Range(0, rooms.roomLeftEntrys.Length);
                        Instantiate(rooms.roomLeftEntrys[rnd], this.transform.position, this.transform.rotation);
                    }
                }
            }
            if (sd == SpawnDir.bottom)
            {
                if (rooms.GetGenTime() <= 0f)
                {
                    Instantiate(rooms.bottomBlocker, this.transform.position, this.transform.rotation);
                }
                else
                {
                    if (Random.Range(1, 3) == 1)
                    {
                        int rnd = Random.Range(0, rooms.hallwayBottomEntrys.Length);
                        Instantiate(rooms.hallwayBottomEntrys[rnd], this.transform.position, this.transform.rotation);
                    }
                    else
                    {
                        int rnd = Random.Range(0, rooms.roomBottomEntrys.Length);
                        Instantiate(rooms.roomBottomEntrys[rnd], this.transform.position, this.transform.rotation);
                    }
                }
            }
            if (sd == SpawnDir.right)
            {
                if (rooms.GetGenTime() <= 0f)
                {
                    Instantiate(rooms.rightBlocker, this.transform.position, this.transform.rotation);
                }
                else
                {
                    if (Random.Range(1, 3) == 1)
                    {
                        int rnd = Random.Range(0, rooms.hallwayRightEntrys.Length);
                        Instantiate(rooms.hallwayRightEntrys[rnd], this.transform.position, this.transform.rotation);
                    }
                    else
                    {
                        int rnd = Random.Range(0, rooms.roomRightEntrys.Length);
                        Instantiate(rooms.roomRightEntrys[rnd], this.transform.position, this.transform.rotation);
                    }
                }
            }
            spawned = true;
        }
    }

    public void SetSpawned(bool spawned)
    {
        this.spawned = spawned;
    }
}
