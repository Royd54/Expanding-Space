using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] enemys;
    public bool bossSpawner = false;
    [SerializeField] private GameObject boss;
    private GameObject player;
    private SpawnRoom rooms;
    private bool spawned = false;

    void Start()
    {
        rooms = GameObject.FindWithTag("Rooms").GetComponent<SpawnRoom>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.B) && bossSpawner)
        {
            player.transform.position = this.transform.position;
        }
        if(rooms.GetGenTime() <= 0f && !spawned)
        {
            if (!player)
            {
                try
                {
                    player = GameObject.FindWithTag("Player");
                }
                catch
                {

                }
            }
            else
            {
                if (Vector2.Distance(GameObject.FindWithTag("Player").transform.position, this.transform.position) < 25f)
                {
                    if (!bossSpawner)
                        Instantiate(enemys[Random.Range(0, enemys.Length)], this.transform.position, this.transform.rotation);
                    else
                        Instantiate(boss, this.transform.position, this.transform.rotation);
                    spawned = true;
                }
            }
        }  
    }

    private void BossSpawner()
    {
        bossSpawner = true;
    }
}
