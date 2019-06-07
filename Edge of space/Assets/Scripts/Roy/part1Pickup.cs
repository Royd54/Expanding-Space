using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class part1Pickup : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject interactKey;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < 2)
        {
            interactKey.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                //GameObject.Find("Player").GetComponent<Inventory>().part1Collected = true;
                Destroy(this.gameObject);
            }
        }
        else
        {
            interactKey.SetActive(false);
        }
    }
}
