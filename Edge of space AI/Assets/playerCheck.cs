using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerCheck : MonoBehaviour
{

    public GameObject enemy;
    private Transform player;
    public bool trigger = false;

    private void Start()
    {
        player = GameObject.Find("Player").GetComponent<Transform>();
        //speed = enemy.GetComponent<EnemyController>().speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        //sets boolean to true on trigger of an collision
        if (collision.gameObject.name == "Player")
        {
            trigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //if the object that triggered exits the range of the collider
        //it sets the boolean to false
        if (collision.gameObject.name == "Player")
        {
            trigger = false;
        }
    }
}