using System.Collections;
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
        transform.position += transform.right * speed * Time.deltaTime;
        if (Vector3.Distance(this.transform.position, player.transform.position) > 50.0f)
            Destroy(this.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.tag == "enemy")
            collision.gameObject.SendMessage("TakeDamage", damage);
    }

    private void SetDamage(int damage)
    {
        this.damage = damage;
    }
    private void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
