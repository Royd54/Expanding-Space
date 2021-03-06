﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float speed;
    private int damage;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        transform.position += transform.right * speed * Time.deltaTime;//moves the bullet to the right
        if (Vector3.Distance(this.transform.position, player.transform.position) > 30.0f)
            Destroy(this.gameObject);//if the bullet is more than 50 units away it will be destroyed
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag != "Player" && collision.gameObject.tag != "bullet")
            Destroy(this.gameObject);

        //if the bullets hits an object with the tag enemy it will look for the function TakeDamage 
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(this.transform.right * (damage * 10));
            collision.gameObject.SendMessage("TakeDamage", damage);
            collision.gameObject.SendMessage("whiteFlash");
        }
    }

    //sets the damage and speed of the pulled this is called by the gun that fired it
    private void SetDamage(int damage)
    {
        this.damage = damage;
    }
    private void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
