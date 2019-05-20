using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSystem : MonoBehaviour
{
    public GameObject crawler;
    public GameObject witch;
    public float spawnTime = 3f;
    private float startTime;
    public Transform[] spawnpoints;
    private int spawnCap = 10;
    public int enemyCount = 0;
    public float bossTimer = 1f;
    private float scinameticTimer = 1f;
    private bool witchSpawned = false;
    public Camera camera;
    public Camera camera3;
    private Camera camera2;
    private float speed = 5f;
    public Transform witchTrans;

    // Start is called before the first frame update
    void Start()
    {
        startTime = spawnTime;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        //camera = GameObject.Find("Main Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        spawnTime -= Time.deltaTime;
        bossTimer -= Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        if (spawnTime <= 0)
        {
            spawnTime = startTime;
            if (enemyCount < spawnCap)
            {
                int SpawnPointIndex = Random.Range(0, spawnpoints.Length);

                Instantiate(crawler, spawnpoints[SpawnPointIndex].position, spawnpoints[SpawnPointIndex].rotation);
                enemyCount++;
            }
        }

        if (bossTimer <= 0)
        {
            spawnCap = 0;
            if (enemyCount <= 0 && witchSpawned == false)
            {
                int SpawnPointIndex = Random.Range(0, spawnpoints.Length);

                Instantiate(witch, spawnpoints[SpawnPointIndex].position, spawnpoints[SpawnPointIndex].rotation);
                witchSpawned = true;
                camera2 = GameObject.Find("Camera2").GetComponent<Camera>();
                StartCoroutine(theSequence());
            }
        }

    }

    IEnumerator theSequence()
    {
        camera2.enabled = true;
        camera.enabled = false;
        yield return new WaitForSeconds(1);
        camera.enabled = true;
        camera2.enabled = false;

    }
}
