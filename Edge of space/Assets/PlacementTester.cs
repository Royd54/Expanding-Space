using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlacementTester : MonoBehaviour
{
    private float halfLife = 0.3f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(transform.parent.gameObject);
    }

    private void Update()
    {
        if (halfLife > 0)
        {
            halfLife -= Time.deltaTime;
            if (halfLife <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
