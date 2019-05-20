﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("PlayerStats")]
    [Range(0,100)]
    public float health;
    [Range(0, 100)]
    public float food;
    [Range(0, 100)]
    public float water;
    [Header("bars/text")]
    public Image healthBar;
    public Image foodBar;
    public Image waterBar;

    public GameObject playerUI;
    public GameObject GameOver;

    private Material matDefault;
    public Material matWhite;
    SpriteRenderer sr;

    private void Start()
    {
        sr = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        matDefault = sr.material;
    }

    // Update is called once per frame
    void Update()
    {
        food -= (0.05f * Time.deltaTime);
        water -= (0.1f * Time.deltaTime);
        //
        if (food <= 0)
        {
            health -= (1 * Time.deltaTime);
            if (health <= 0)
            {
                Destroy(GameObject.FindWithTag("Player"));
            }
        } 
        if (water <= 0)
        {
            health -= (1 * Time.deltaTime);
            if (health <= 0)
            {
                Destroy(GameObject.FindWithTag("Player"));
            }
        }
        MoveBars();
    }

    private void TakeDamage(float damage)
    {
        health -= damage;
        whiteFlash();
        Debug.Log(health);
        if (health <= 0)
        {
            Destroy(GameObject.FindWithTag("Player"));
            playerUI.SetActive(false);
            GameOver.SetActive(true);
        }
    }
    
    //sets all the bars and the text in them to the corect value
    private void MoveBars()
    {
        healthBar.fillAmount = health / 100;
        foodBar.fillAmount = food / 100;
        waterBar.fillAmount = water / 100;
    }

    //sets the object its color to white
    void whiteFlash()
    {
        sr.material = matWhite;
        Invoke("ResetMaterial", 0.2f);
    }

    //resets the material to the default color
    void ResetMaterial()
    {
        sr.material = matDefault;
    }

}
