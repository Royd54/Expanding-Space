using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    public float speed;

    private Transform player;
    private Vector2 target;
    public float damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += transform.right * speed * Time.deltaTime;

        if (Vector2.Distance(transform.position, player.position) > 30)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if the projectile collides with the player it deals damage and destroys itself
        if (collision.gameObject.name == "Player")
        {
            player.GetComponent<Rigidbody2D>().AddForce(this.transform.Find("KnockBackPoint").right * (damage * 10));
            player.SendMessage("TakeDamage", damage);
            DestroyProjectile();
        }
        else if(collision.gameObject.tag == "bullet")
        {
            DestroyProjectile();
        }
    }

    //destroys the gameobject
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


}
