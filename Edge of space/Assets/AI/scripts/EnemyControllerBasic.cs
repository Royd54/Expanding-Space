using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBasic : MonoBehaviour
{

    [SerializeField] private float speed;
    private float waitTime;
    [SerializeField] private float startWaitTime;

    private Transform moveSpot;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    private GameObject player;
    private Animator anim;

    [SerializeField] private float damage = 35;
    [SerializeField] private float fireRate = 1F;
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
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

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
            transform.position = Vector2.MoveTowards(transform.position, moveSpot.position, speed * Time.deltaTime);

            //if the enemy is at the movespot he waits before he goes on
            if (Vector2.Distance(transform.position, moveSpot.position) < 10f)
            {
                if (waitTime <= 0)
                {
                    //sets a new random movespot after he waited
                    moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
                    waitTime = startWaitTime;
                }
                //counts down
                else
                {
                    anim.SetBool("isFollowing", false);
                    anim.SetBool("isAttacking", false);
                    anim.SetBool("isPatrolling", false);
                    waitTime -= Time.deltaTime;
                }
            }
        }

        //if the player is in range the enemy starts moving towards the player (via the chase function)
        if (Vector3.Distance(transform.position, player.transform.position) <= 30f)
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isPatrolling", false);
            Chase();
        }
    }

    public void Chase()
    {
        speed = 5;
        //if the player is in range for melee attack it stops moving and starts damaging the player
        if (Vector3.Distance(transform.position, player.transform.position) <= 2.5f)
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