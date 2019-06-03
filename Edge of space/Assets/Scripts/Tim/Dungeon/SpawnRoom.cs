﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField] private float genTime = 10f;
    [SerializeField] private GameObject player;
    private bool spawned = false;

    [Header("Hallways")]
    [Tooltip("All Hallways with a top entry point")]
    public GameObject[] hallwayTopEntrys;
    [Tooltip("All Hallways with a right entry point")]
    public GameObject[] hallwayRightEntrys;
    [Tooltip("All Hallways with a bottom entry point")]
    public GameObject[] hallwayBottomEntrys;
    [Tooltip("All Hallways with a left entry point")]
    public GameObject[] hallwayLeftEntrys;

    [Header("Rooms")]
    [Tooltip("All Room with a top entry point")]
    public GameObject[] roomTopEntrys;
    [Tooltip("All Room with a right entry point")]
    public GameObject[] roomRightEntrys;
    [Tooltip("All Room with a bottom entry point")]
    public GameObject[] roomBottomEntrys;
    [Tooltip("All Room with a left entry point")]
    public GameObject[] roomLeftEntrys;
    
    public GameObject topBlocker, leftBlocker, bottomBlocker, rightBlocker;
    public List<GameObject> allRooms = new List<GameObject>();

    private void Update()
    {
        if (genTime > 0)
        {
            genTime -= Time.deltaTime;
            if (genTime <= 0)
            {
                if(!spawned)
                    Instantiate(player, this.transform.position, this.transform.rotation);
            }
        }
    }

    public float GetGenTime()
    {
        return genTime;
    }
}