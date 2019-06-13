﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveAI : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;

    [SerializeField] private bool spotted = false;

    private float distance = 10f;

    [SerializeField] private GameObject player;
    private Animator anim;

    [SerializeField] private float damage = 35;
    [SerializeField] private float fireRate = 1F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        speed = 2;

        Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), this.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
            Chase();
    }

    public void Chase()
    { 
        speed = 3;
        spotted = true;
        //if the player is in range for melee attack it stops moving and starts damaging the player
        if (Vector3.Distance(transform.position, player.transform.position) <= 2.5f)
        {
            anim.SetBool("isFollowing", false);
            anim.SetBool("isAttacking", true);
            //anim.SetBool("isPatrolling", false);
            transform.position = this.transform.position;

            if (Time.time > nextFire)
            {
                //does damage if the timer is 0
                nextFire = Time.time + fireRate;
                player.GetComponent<Rigidbody2D>().AddForce(this.transform.Find("KnockBackPoint").right * (damage * 10));
                player.SendMessage("TakeDamage", damage);
            }

             //transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        //he walks towards the player
        else
        { 
            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            anim.SetBool("isFollowing", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }

    }
}