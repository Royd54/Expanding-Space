using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMinon : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;

    private GameObject player;
    private Vector2 target;
    private Rigidbody2D prb;
    private Transform KnockBackPoint;
    private Animator anim;

    public float damage = 15;
    public float fireRate = 1F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        prb = player.GetComponent<Rigidbody2D>();
        target = new Vector2(player.transform.position.x, player.transform.position.y);
        KnockBackPoint = transform.Find("KnockBackPointer");
        anim = this.gameObject.GetComponent<Animator>();
    }
    
    void FixedUpdate()
    {
        //checks the distance between the player and the minion
        if (Vector2.Distance(transform.position, player.transform.position) < stoppingDistance)
        {
            transform.position = this.transform.position;

            if (Time.time > nextFire)
            {
                //Damage per a couple seconds
                nextFire = Time.time + fireRate;
                anim.SetBool("isAttacking", true);
                anim.SetBool("isFollowing", false);
                //player.GetComponent<Rigidbody2D>().AddForce(KnockBackPoint.right * 30000);
                player.SendMessage("TakeDamage", damage);
            }
        }
        //if the distance is larger than the stopping distance it moves towards the player
        else
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isFollowing", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

    }

}