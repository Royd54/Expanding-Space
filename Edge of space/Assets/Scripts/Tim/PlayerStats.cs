using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour
{
    [Header("PlayerStats")]
    [Range(0,100)]
    private static float HEALTH = 33;
    private float health;
    [Range(0, 100)]
    private static float FOOD = 100;
    private float food;
    [Range(0, 100)]
    private static float WATER = 100;
    private float water;
    [Header("bars/text")]
    public Image healthBar;
    public Image foodBar;
    public Image waterBar;

    private bool godMode = false;
    private AudioSource audioS;

    public GameObject playerUI;
    public GameObject GameOver;
    public GameObject Victory;

    private GameObject witch;

    private Material matDefault;
    public Material matWhite;
    private SpriteRenderer sr;
    private float damageCoolDown = 1f;

    private void Start()
    {
        sr = GameObject.Find("Player").GetComponent<SpriteRenderer>();
        matDefault = sr.material;
        audioS = GameObject.Find("audioHandler").GetComponent<AudioSource>();
        health = HEALTH;
        food = FOOD;
        water = WATER;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.G))
        {
            if (!godMode)
                godMode = true;
            else
                godMode = false;
        }
        SetStats();

        food -= (0.25f * Time.deltaTime);
        water -= (0.5f * Time.deltaTime);
        
        if (food <= 0)
        {
            health -= (1 * Time.deltaTime);
            if (health <= 0)
            {
                if (damageCoolDown <= 0)
                {
                    TakeDamage(1f);
                    damageCoolDown = 1f;
                }
                else
                {
                    damageCoolDown -= Time.deltaTime;
                }
            }
        } 
        if (water <= 0)
        {
            if (damageCoolDown <= 0)
            {
                TakeDamage(1f);
                damageCoolDown = 1f;
            }
            else
            {
                damageCoolDown -= Time.deltaTime;
            }
        }
        MoveBars();
    }

    private void TakeDamage(float damage)
    {
        audioS.Play();
        if(!godMode)
            health -= damage;
        MoveBars();
        whiteFlash();
        if (health <= 0)
        {
            Destroy(GameObject.Find("Player"));
            playerUI.SetActive(false);
            GameOver.SetActive(true);
        }
    }
    
    //sets all the bars and the text in them to the corect value
    private void MoveBars()
    {
        try
        {
            healthBar.fillAmount = health / 100;
            foodBar.fillAmount = food / 100;
            waterBar.fillAmount = water / 100;
        }
        catch
        {
            //do nothing
        }
    }

    //sets the object its color to white
    private void whiteFlash()
    {
        sr.material = matWhite;
        Invoke("ResetMaterial", 0.2f);
    }

    //resets the material to the default color
    private void ResetMaterial()
    {
        sr.material = matDefault;
    }

    public void SetHealth(float health, bool godMode)
    {
        if(health + this.health > 100 && !godMode)
        {
            this.health = health;
        }
        else
        {
            this.health = health;
        }
    }
    public float GetHealth()
    {
        return HEALTH;
    }

    public void SetFood(float food)
    {
        if(food + this.food > 100)
        {
            this.food = 100f;
        }
        else
        {
            this.food = food;
        }
    }
    public float GetFood()
    {
        return FOOD;
    }

    public void SetWater(float water)
    {
        if (water + this.water > 100)
        {
            this.water = 100f;
        }
        else
        {
            this.water = water;
        }
    }
    public float GetWater()
    {
        return WATER;
    }

    private void SetStats()
    {
        HEALTH = health;
        FOOD = food;
        WATER = water;
    }

    public void SetGodmode(bool setGodmode)
    {
        if (setGodmode == true)
        {
            godMode = true;
        }
        else
        {
            godMode = false;
        }
    }

}
