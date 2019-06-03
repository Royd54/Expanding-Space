using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flesh : MonoBehaviour
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
        if(Vector2.Distance(transform.position, player.transform.position) < 4)
        {
            interactKey.SetActive(true);
            if(Input.GetKey(KeyCode.E))
            {
                player.GetComponent<PlayerStats>().food += 42;
                Destroy(this.gameObject);
            }
        }
        else
        {
            interactKey.SetActive(false);
        }
    }
}
