﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMinon : MonoBehaviour
{

    public float speed;
    public float stoppingDistance;

    private Transform player;
    private Vector2 target;

    public int damage = 15;
    public float fireRate = 1F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void Update()
    {
        //checks the distance between the player and the minion
        if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = this.transform.position;

            if (Time.time > nextFire)
            {
                //Damage per a couple seconds
                nextFire = Time.time + fireRate;
                player.SendMessage("TakeDamage", damage);
            }
        }
        //if the distance is larger than the stopping distance it moves towards the player
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }

    }
}