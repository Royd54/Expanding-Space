using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DungeonEntrace : MonoBehaviour
{
    [SerializeField] private int amountOfFloors = 3;
    private GameObject player;
    private GameObject interactKey;
    private static int amountOfDungeonsEntered = 0;
    public static int toFloor = 0;

    void Start()
    {
        player = GameObject.FindWithTag("Player");
        interactKey = this.transform.Find("E").gameObject;
        interactKey.SetActive(false);
    }
    
    void Update()
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
}
