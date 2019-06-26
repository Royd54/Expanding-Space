using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipPart : MonoBehaviour
{
    private enum Part
    {
        none,
        Part1,
        Part2,
        Part3
    }
    [SerializeField] private Part part = Part.none;
    private GameObject player;
    private GameObject interactKey;
    private PlayButton levelLoader;
    private bool done = false;

    private void Start()
    {
        Debug.Log("shipPart");
        levelLoader = GameObject.FindWithTag("ButtonHendler").GetComponent<PlayButton>();
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
                    switch (part)
                    {
                        case Part.none:
                            levelLoader.LoadLevelByName("EndingScene");
                            break;
                        case Part.Part1:
                            GameObject.Find("Player").GetComponent<Inventory>().setPart1();
                            levelLoader.LoadLevelByName("EndingScene");
                            break;
                        case Part.Part2:
                            GameObject.Find("Player").GetComponent<Inventory>().setPart2();
                            levelLoader.LoadLevelByName("EndingScene");
                            break;
                        case Part.Part3:
                            GameObject.Find("Player").GetComponent<Inventory>().setPart3();
                            levelLoader.LoadLevelByName("EndingScene");
                            break;
                        default:
                            break;
                    }
                        
                }
            }
            else
            {
                interactKey.SetActive(false);
            }
        }
    }
}
