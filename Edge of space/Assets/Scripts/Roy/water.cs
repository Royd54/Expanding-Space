using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Water : MonoBehaviour
{
    private GameObject player;
    private GameObject interactKey;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        interactKey = this.transform.Find("E").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 5)
        {
            interactKey.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                player.GetComponent<PlayerStats>().SetWater(player.GetComponent<PlayerStats>().GetWater() + 25f);
            }
        }
        else
        {
            interactKey.SetActive(false);
        }
    }
}
