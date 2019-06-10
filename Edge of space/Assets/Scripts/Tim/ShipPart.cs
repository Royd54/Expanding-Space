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

    private void Start()
    {
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
                    SceneManager.LoadScene("PlaytestOverworld");
                }
            }
            else
            {
                interactKey.SetActive(false);
            }
        }
    }
}
