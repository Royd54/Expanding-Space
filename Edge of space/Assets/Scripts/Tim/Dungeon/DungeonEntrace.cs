using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonEntrace : MonoBehaviour
{
    private enum Part
    {
        none,
        Part1,
        Part2,
        Part3
    }
    [SerializeField] private Part part = Part.none;
    [SerializeField] private int amountOfFloors = 3;
    private static GameObject[] SHIPPARTS;
    [SerializeField] private GameObject[] shipParts;
    private static int partToSpawn = 0;
    private bool shuffled = false;
    private GameObject player;
    private GameObject interactKey;
    private static int amountOfDungeonsEntered = 0;
    public static int toFloor = 0;
    
    private void OnEnable()
    {
        if(!shuffled)
        {
            ShuffleArray(shipParts);
            SHIPPARTS = shipParts;
            shuffled = true;
        }
        if(amountOfFloors == toFloor)
        {
            if (SHIPPARTS[partToSpawn].transform.name != "DONOTDELETE")
            {
                Destroy(this.gameObject);
                Instantiate(SHIPPARTS[partToSpawn], this.transform.position, this.transform.rotation);
            }
            partToSpawn++;
        }
        player = GameObject.FindWithTag("Player");
        interactKey = this.transform.Find("E").gameObject;
        interactKey.SetActive(false);
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
                    switch(part)
                    {
                        case Part.Part1:
                            GameObject.Find("Player").GetComponent<Inventory>().setPart1();
                            break;
                        case Part.Part2:
                            GameObject.Find("Player").GetComponent<Inventory>().setPart2();
                            break;
                        case Part.Part3:
                            GameObject.Find("Player").GetComponent<Inventory>().setPart3();
                            break;
                        default:
                            break;
                    }
                    if (amountOfFloors == toFloor)
                    {
                        toFloor = 0;
                        SceneManager.LoadScene("PlaytestOverworld");
                    }
                    else
                    {
                        if (toFloor == 0)
                        {
                            SceneManager.LoadScene("Generator");
                        }
                        else
                        {
                            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                        }
                        toFloor++;
                    }
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
