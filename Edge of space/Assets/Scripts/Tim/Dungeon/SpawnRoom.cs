using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnRoom : MonoBehaviour
{
    [SerializeField] private GameObject player;
    private bool spawned = false;
    [SerializeField] private GameObject nextFloor;
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
    public List<GameObject> allRooms = new List<GameObject>();

    private void Update()
    {
        if (genTime > 0)
        {
            genTime -= Time.deltaTime;
            if (genTime <= 0 && !spawned)
            {
                BossRoom(allRooms[allRooms.Count-1]);
                if (allRooms.Count < 5f)
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                spawned = true;
            }
        }
    }

    public float GetGenTime()
    {
        return genTime;
    }

    private void BossRoom(GameObject room)
    {
        Instantiate(nextFloor, allRooms[allRooms.Count - 1].transform.Find("EnemySpawner").position, allRooms[allRooms.Count - 1].transform.Find("EnemySpawner").rotation);
        Destroy(room.transform.Find("EnemySpawner").gameObject);
    }
}
