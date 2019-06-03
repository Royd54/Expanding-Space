using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBasic : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float waitTime;
    [SerializeField] private float startWaitTime;

    private Vector2 moveSpot;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    private GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        waitTime = startWaitTime;
        //sets a random moveposition between the x and the y values
        moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        speed = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //checks if the player is in range of the enemy
        if (Vector3.Distance(transform.position, player.transform.position) > 5f)
        {
            //moves towards the movespot
            transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, moveSpot) <= 0)
        {
            waitTime -= Time.deltaTime;
        }

        if (waitTime <= 0)
        {
            //sets a new random movespot after he waited
            moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            waitTime = startWaitTime;
        }
    }
}