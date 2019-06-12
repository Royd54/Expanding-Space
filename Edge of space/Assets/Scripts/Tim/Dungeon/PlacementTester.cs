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
            switch(words[0])
            {
                case "T":
                    Instantiate(rooms.topBlocker, this.transform.parent.position, this.transform.parent.rotation);
                    break;
                case "L":
                    Instantiate(rooms.leftBlocker, this.transform.parent.position, this.transform.parent.rotation);
                    break;
                case "B":
                    Instantiate(rooms.bottomBlocker, this.transform.parent.position, this.transform.parent.rotation);
                    break;
                case "R":
                    Instantiate(rooms.rightBlocker, this.transform.parent.position, this.transform.parent.rotation);
                    break;
                default:
                    Debug.LogWarning("Parent does not have T/L/B/R at the start of the name");
                    break;
            }

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
                if(isRoom)
                    rooms.allRooms.Add(this.transform.parent.gameObject);
                Destroy(this.gameObject);
            }
        }
    }
}
