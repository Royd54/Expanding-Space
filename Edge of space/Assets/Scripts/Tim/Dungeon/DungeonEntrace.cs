using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonEntrace : MonoBehaviour
{
    [SerializeField] private int amountOfFloors = 3;
    private static GameObject[] SHIPPARTS;
    [SerializeField] private GameObject[] shipParts;
    private static int partToSpawn = 0;
    private bool shuffled = false;
    private GameObject player;
    private GameObject interactKey;
    private static int amountOfDungeonsEntered = 0;
    private static int currentFloor = 0;
    
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        interactKey = this.transform.Find("E").gameObject;
        interactKey.SetActive(false);
        if (!shuffled)
        {
            ShuffleArray(shipParts);
            SHIPPARTS = shipParts;
            shuffled = true;
        }
        if(amountOfFloors == currentFloor)
        {
            if (SHIPPARTS[partToSpawn].transform.name != "DONOTDELETE")
            {
                Destroy(this.gameObject);
                Instantiate(SHIPPARTS[partToSpawn], this.transform.position, this.transform.rotation);
            }
            partToSpawn++;
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
                if (Input.GetKey(KeyCode.E))
                {
                    if (amountOfFloors == currentFloor)
                    {
                        SceneManager.LoadScene("PlaytestOverworld");
                    }
                    SceneManager.LoadScene("Generator");
                    currentFloor++;
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
