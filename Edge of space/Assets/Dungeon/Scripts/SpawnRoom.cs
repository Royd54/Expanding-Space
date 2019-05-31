using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField] private float genTime = 10f;

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
    public GameObject[] allRooms;

    private void Update()
    {
        if (genTime > 0)
        {
            genTime -= Time.deltaTime;
            if (genTime <= 0)
            {
                EndGeneration();
            }
        }
    }

    private void EndGeneration()
    {

    }
}
