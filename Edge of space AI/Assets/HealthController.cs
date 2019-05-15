using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    [SerializeField] private float health;
    private float randomHP;


    private void Start()
    {
        //sets the hp to a random value between 10 and 40
        randomHP = Random.Range(10f, 40f);
        health = randomHP;
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

}
