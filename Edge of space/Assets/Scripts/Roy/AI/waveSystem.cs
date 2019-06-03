﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveSystem : MonoBehaviour
{
    [SerializeField]private GameObject crawler;
    [SerializeField] private GameObject witch;

    [SerializeField] private float spawnTime = 3f;
    private float startTime;
    [SerializeField] private float bossTimer = 1f;
    private float scinameticTimer = 1f;

    [SerializeField] private Transform[] spawnpoints;
    private int spawnCap = 10;
    public int enemyCount = 0;

    public bool witchSpawned = false;

    [SerializeField] private Camera camera;
    [SerializeField] private Camera camera3;
    [SerializeField] private Camera camera2;

    private float speed = 5f;
    [SerializeField] private Transform witchTrans;

    // Start is called before the first frame update
    void Start()
    {
        //sets the starttime and keeps repeating with the timer's interval
        startTime = spawnTime;
        InvokeRepeating("Spawn", spawnTime, spawnTime);
    }

    private void Update()
    {
        //counts down with time.deltatime, because of framerate
        spawnTime -= Time.deltaTime;
        bossTimer -= Time.deltaTime;
        Spawn();
    }

    void Spawn()
    {
        //if the spawntime == 0 a enemy gets spawned at a random location
        //This location is one of the spawnpoints in the map
        if (spawnTime <= 0)
        {
            spawnTime = startTime;
            if (enemyCount < spawnCap)
            {
                int SpawnPointIndex = Random.Range(0, spawnpoints.Length);
                //the enemycount also gests updated, because u don't want unlimited enemy's
                Instantiate(crawler, spawnpoints[SpawnPointIndex].position, spawnpoints[SpawnPointIndex].rotation);
                enemyCount++;
            }
        }

        //if the bossTimer == 0 it spawns the bos and maxes out he enemycount
        //Because of this the little enemy's won't spawn anymore
        if (bossTimer <= 0)
        {
            spawnCap = 0;
            if (enemyCount <= 0 && witchSpawned == false)
            {
                enemyCount += 10;
                int SpawnPointIndex = Random.Range(0, spawnpoints.Length);

                Instantiate(witch, spawnpoints[SpawnPointIndex].position, spawnpoints[SpawnPointIndex].rotation);
                witchSpawned = true;
                //Here i start the sequence of the enemy scinametic
                camera2 = GameObject.Find("Camera2").GetComponent<Camera>();
                StartCoroutine(theSequence());
            }
        }

    }

    //here is aneble and disable the cameras over time (the scinametic is made with animations)
    IEnumerator theSequence()
    {
        camera2.enabled = true;
        camera.enabled = false;
        yield return new WaitForSeconds(1);
        camera.enabled = true;
        camera2.enabled = false;

    }
}