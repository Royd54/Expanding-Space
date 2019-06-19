using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openWorldAI : MonoBehaviour
{
    [SerializeField] private GameObject corpse;

    [SerializeField] private float speed;

    [SerializeField] private float waitTime;
    [SerializeField] private float startWaitTime;

    private Vector2 moveSpot;
    private Vector2 beginpos;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;

    [SerializeField] private bool spotted = false;

    private float distance = 10f;

    private GameObject player;
    private Animator anim;

    [SerializeField] private float damage = 35;
    [SerializeField] private float fireRate = 1F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        waitTime = startWaitTime;
        //sets a random moveposition between the x and the y values
        moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        beginpos = this.gameObject.transform.position;
        speed = 2;

        Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), this.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.gameObject.GetComponent<HealthController>().health <= 0)
        {
            Instantiate(corpse, this.gameObject.transform.position, Quaternion.identity);
        }

        if (spotted == false) { 
        if (Vector3.Distance(transform.position, moveSpot) > 0f)
        {
            //moves towards the movespot
            transform.position = Vector2.MoveTowards(transform.position, moveSpot, speed * Time.deltaTime);
            anim.SetBool("isWalking", true);

        }

        if (Vector3.Distance(transform.position, moveSpot) <= 0)
        {
            waitTime -= Time.deltaTime;
            anim.SetBool("isWalking", false);
        }

        if (waitTime <= 0)
        {
            //sets a new random movespot after he waited
            moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            waitTime = startWaitTime;
        }
        }

        if (Vector3.Distance(transform.position, player.transform.position) <= 10f)
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isPatrolling", false);
            Chase();
        }
        else
        {
            spotted = false;
        }

    }

    public void Chase()
    { 
        speed = 3;
        spotted = true;
        //if the player is in range for melee attack it stops moving and starts damaging the player
        if (Vector3.Distance(transform.position, player.transform.position) <= 3f)
        {
            anim.SetBool("isFollowing", false);
            anim.SetBool("isAttacking", true);
            //anim.SetBool("isPatrolling", false);
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
            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            anim.SetBool("isFollowing", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }

    }
}