﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class witchHealthController : MonoBehaviour
{
    [SerializeField] public float health;
    private Material matDefault;
    public Material matWhite;
    SpriteRenderer sr;
    private AudioSource audioS;
    [SerializeField] private Image Hpbar;


    private void Start()
    {
        //sets the hp to 100
        health = 100f;

        sr = this.gameObject.GetComponent<SpriteRenderer>();
        matDefault = sr.material;

        audioS = GameObject.Find("audioHandler").GetComponent<AudioSource>();
    }

    //this function can be called to cause damage to the object it is on
    public void TakeDamage(float damage)
    {
        audioS.Play();
        health -= damage;
        Hpbar.fillAmount = health / 100;
        //if health is below 0 it destroys itself
        if (health <= 0)
        {
            //this gets handled in the playerstats script
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