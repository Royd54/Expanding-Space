using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementTester : MonoBehaviour
{
    private float halfLife = 0.3f;
    private SpawnRoom rooms;
    private string name;
    private string[] words;
    [SerializeField] private bool isRoom = false;
    private bool spawned = false;

    private void Start()
    {
        rooms = GameObject.FindWithTag("Rooms").GetComponent<SpawnRoom>();
        name = this.transform.parent.name;
        words = name.Split(' ');
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!spawned)
        {
            /*if (isRoom)
            {
                if(words[0] == "T")
                {
                    int rnd = Random.Range(0, rooms.hallwayTopEntrys.Length);
                    Instantiate(rooms.hallwayTopEntrys[rnd], this.transform.parent.position, this.transform.parent.rotation);
                }
                if(words[0] == "L")
                {
                    int rnd = Random.Range(0, rooms.hallwayLeftEntrys.Length);
                    Instantiate(rooms.hallwayLeftEntrys[rnd], this.transform.parent.position, this.transform.parent.rotation);
                }
                if(words[0] == "B")
                {
                    int rnd = Random.Range(0, rooms.hallwayBottomEntrys.Length);
                    Instantiate(rooms.hallwayBottomEntrys[rnd], this.transform.parent.position, this.transform.parent.rotation);
                }
                if(words[0] == "R")
                {
                    int rnd = Random.Range(0, rooms.hallwayRightEntrys.Length);
                    Instantiate(rooms.hallwayRightEntrys[rnd], this.transform.parent.position, this.transform.parent.rotation);
                }
            }*/
            if (words[0] == "T")
                Instantiate(rooms.topBlocker, this.transform.parent.position, this.transform.parent.rotation);
            if (words[0] == "L")
                Instantiate(rooms.leftBlocker, this.transform.parent.position, this.transform.parent.rotation);
            if (words[0] == "B")
                Instantiate(rooms.bottomBlocker, this.transform.parent.position, this.transform.parent.rotation);
            if (words[0] == "R")
                Instantiate(rooms.rightBlocker, this.transform.parent.position, this.transform.parent.rotation);

            spawned = true;
            Destroy(transform.parent.gameObject);
        }
    }

    private void Update()
    {
        if (halfLife > 0)
        {
            halfLife -= Time.deltaTime;
            if (halfLife <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
