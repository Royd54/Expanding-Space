using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private float speed;

    private Transform player;
    private Vector2 target;
    [SerializeField] private float damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        //attaches the player and target variable to the player info
        player = GameObject.Find("Player").transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //travels straight ahead after instatiation of the object
        transform.position += transform.right * speed * Time.deltaTime;

        //if the porjectile is to far away from the player it destroys itself to safe memory
        if (Vector2.Distance(transform.position, player.position) > 30)
        {
            DestroyProjectile();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.name);
        if (collision.gameObject != GameObject.FindGameObjectWithTag("enemy"))
        {
            //if the projectile collides with the player it deals damage and destroys itself
            if (collision.gameObject.name == "Player")
            {
                player.GetComponent<Rigidbody2D>().AddForce(this.transform.Find("KnockBackPoint").right * (damage * 10));
                player.SendMessage("TakeDamage", damage);
                DestroyProjectile();
            }
            else
            {
                DestroyProjectile();
            }
        }
    }

    //destroys the gameobject
    void DestroyProjectile()
    {
        Destroy(gameObject);
    }


}
