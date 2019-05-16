﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float health;
    private float randomHP;
    private Material matDefault;
    public Material matWhite;
    SpriteRenderer sr;

    private void Start()
    {
        //sets the hp to a random value between 10 and 40
        randomHP = Random.Range(10f, 40f);
        health = randomHP;

        sr = this.gameObject.GetComponent<SpriteRenderer>();
        matDefault = sr.material;
    }

    //this function can be called to cause damage to the object it is on
    public void TakeDamage(float damage)
    {
        health -= damage;

        //if health is below 0 it destroys itself
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    //sets the object its color to white
    public void whiteFlash()
    {
        sr.material = matWhite;
        Invoke("ResetMaterial", 0.2f);
    }

    //resets the material to the default color
    public void ResetMaterial()
    {
        sr.material = matDefault;
    }


}
