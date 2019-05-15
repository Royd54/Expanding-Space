using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class witchHealthController : MonoBehaviour
{
    [SerializeField] private float health;

    private void Start()
    {
        //sets the hp to 100
        health = 100f;
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
