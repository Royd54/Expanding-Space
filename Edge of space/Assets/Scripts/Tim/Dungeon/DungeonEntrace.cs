using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonEntrace : MonoBehaviour
{
    private enum cave
    {
        none,
        cave1,
        cave2,
        cave3,
        cave4
    }
    private static bool cave1closed, cave2closed, cave3closed, cave4closed;
    [SerializeField] private cave Cave = cave.none;
    [SerializeField] private int amountOfFloors = 3;
    private static GameObject[] SHIPPARTS;
    [SerializeField] private GameObject[] shipParts;
    private static int partToSpawn = 0;
    private bool shuffled = false;
    private GameObject player;
    private GameObject interactKey;
    private static int amountOfDungeonsEntered = 0;
    private static int currentFloor = 0;
    [SerializeField] private GameObject insideEntrance;
    [SerializeField] private Sprite closed;
    private PlayButton levelLoader;
    
    private void Start()
    {
        switch (Cave)
        {
            case cave.cave1:
                if (cave1closed)
                {
                    GetComponent<SpriteRenderer>().sprite = closed;
                    this.GetComponent<DungeonEntrace>().enabled = false;
                }
                break;
            case cave.cave2:
                if (cave2closed)
                {
                    GetComponent<SpriteRenderer>().sprite = closed;
                    this.GetComponent<DungeonEntrace>().enabled = false;
                }
                break;
            case cave.cave3:
                if (cave3closed)
                {
                    GetComponent<SpriteRenderer>().sprite = closed;
                    this.GetComponent<DungeonEntrace>().enabled = false;
                }
                break;
            case cave.cave4:
                if (cave4closed)
                {
                    GetComponent<SpriteRenderer>().sprite = closed;
                    this.GetComponent<DungeonEntrace>().enabled = false;
                }
                break;
            default:
                break;
        }
        levelLoader = GameObject.FindWithTag("ButtonHendler").GetComponent<PlayButton>();
        player = GameObject.FindWithTag("Player");
        interactKey = this.transform.Find("E").gameObject;
        interactKey.SetActive(false);
        if (!shuffled)
        {
            ShuffleArray(shipParts);
            SHIPPARTS = shipParts;
            shuffled = true;
        }
        if (amountOfFloors == currentFloor)
        {
            Debug.Log("part spawned");
            Instantiate(SHIPPARTS[partToSpawn], this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
            currentFloor = 0;
        }
    }

    private void Update()
    {
        if (!player)
        {
            player = GameObject.FindWithTag("Player");
        }
        else
        {
            if (Vector2.Distance(this.transform.position, player.transform.position) < 8f)
            {
                interactKey.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    switch (Cave)
                    {
                        case cave.cave1:
                            cave1closed = true;
                            break;
                        case cave.cave2:
                            cave2closed = true;
                            break;
                        case cave.cave3:
                            cave3closed = true;
                            break;
                        case cave.cave4:
                            cave4closed = true;
                            break;
                        default:
                            break;
                    }
                    currentFloor++;
                    Debug.Log(currentFloor);
                    levelLoader.LoadLevelByName("Generator");
                    Destroy(GameObject.Find("PlayerUI"));
                }
            }
            else
            {
                interactKey.SetActive(false);
            }
        }
    }

    private void ShuffleArray(GameObject[] shipParts)
    {
        for (int i = 0; i < shipParts.Length; i++)
        {
            GameObject _object = shipParts[i];
            int rnd = Random.Range(i, shipParts.Length);
            shipParts[i] = shipParts[rnd];
            shipParts[rnd] = _object;
        }
    }
}
