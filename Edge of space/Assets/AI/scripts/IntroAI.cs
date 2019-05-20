using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAI : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    private Transform moveSpot;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    private GameObject player;
    private Animator anim;

    public float damage = 35;
    public float fireRate = 1F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        //anim = GameObject.Find("Crawler").GetComponent<Animator>();
        player = GameObject.Find("Player");
        waitTime = startWaitTime;
        //sets a random moveposition between the x and the y values
        moveSpot = GameObject.Find("moveSpot").GetComponent<Transform>();

        speed = 2;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //checks if the player is in range of the enemy
        if (Vector3.Distance(transform.position, player.transform.position) > 10f)
        {
            //moves towards the movespot
            anim.SetBool("isPatrolling", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }

        //if the player is in range the enemy starts moving towards the player (via the chase function)
        if (Vector3.Distance(transform.position, player.transform.position) <= 30f)
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isPatrolling", false);
            Chase();
        }
        else
        {
            speed = 2;
        }
    }

    public void Chase()
    {
        speed = 3;
        //if the player is in range for melee attack it stops moving and starts damaging the player
        if (Vector3.Distance(transform.position, player.transform.position) <= 1.8f)
        {
            anim.SetBool("isFollowing", false);
            anim.SetBool("isAttacking", true);
            anim.SetBool("isPatrolling", false);
            transform.position = this.transform.position;

            if (Time.time > nextFire)
            {
                //does damage if the timer is 0
                nextFire = Time.time + fireRate;
                player.GetComponent<Rigidbody2D>().AddForce(this.transform.Find("KnockBackPoint").right * (damage * 10));
                player.SendMessage("TakeDamage", damage);
            }

            // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        //he walks towards the player
        else
        { 
            Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            anim.SetBool("isFollowing", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }

    }
}