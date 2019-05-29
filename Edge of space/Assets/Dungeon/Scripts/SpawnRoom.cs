using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoom : MonoBehaviour
{
    [Header("Hallways")]
    [SerializeField]
    [Tooltip("All Hallways with a top entry point")]
    private List<GameObject> hallwayTopEntrys = new List<GameObject>();
    [SerializeField]
    [Tooltip("All Hallways with a right entry point")]
    private List<GameObject> hallwayRightEntrys = new List<GameObject>();
    [SerializeField]
    [Tooltip("All Hallways with a bottom entry point")]
    private List<GameObject> hallwayBottomEntrys = new List<GameObject>();
    [SerializeField]
    [Tooltip("All Hallways with a left entry point")]
    private List<GameObject> hallwayLeftEntrys = new List<GameObject>();

    [Header("Rooms")]
    [SerializeField]
    [Tooltip("All Room with a top entry point")]
    private List<GameObject> roomTopEntrys = new List<GameObject>();
    [SerializeField]
    [Tooltip("All Room with a right entry point")]
    private List<GameObject> roomRightEntrys = new List<GameObject>();
    [SerializeField]
    [Tooltip("All Room with a bottom entry point")]
    private List<GameObject> roomBottomEntrys = new List<GameObject>();
    [SerializeField]
    [Tooltip("All Room with a left entry point")]
    private List<GameObject> roomLeftEntrys = new List<GameObject>();
}
