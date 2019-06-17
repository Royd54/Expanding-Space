using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroAI : MonoBehaviour
{

    [SerializeField] private float speed;
    private float waitTime;
    [SerializeField] private float startWaitTime;

    private Vector2 beginpos;
    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;

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
        //moveSpot = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
        beginpos = this.gameObject.transform.position;
        speed = 2;

        Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), this.GetComponent<BoxCollider2D>());
    }

    private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Linecast(this.transform.position, player.transform.position * 1);
        
        if(hitInfo.collider != null)
        {
            if (hitInfo.collider.name == "Player")
            {
                Chase();
            }
            else
            {
                Debug.DrawLine(this.transform.position, player.transform.position);
                    //moves towards the movespot
                    anim.SetBool("isPatrolling", true);
                    transform.position = Vector2.MoveTowards(transform.position, beginpos, speed * Time.deltaTime);
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //checks if the player is in range of the enemy
       // if (Vector3.Distance(transform.position, player.transform.position) > 10f)
       // {
       //     //moves towards the movespot
       //     anim.SetBool("isPatrolling", true);
       //     transform.position = Vector2.MoveTowards(transform.position, beginpos, speed * Time.deltaTime);
       // }

        //if the player is in range the enemy starts moving towards the player (via the chase function)
        if (Vector3.Distance(transform.position, player.transform.position) <= 10f)
        {
            anim.SetBool("isAttacking", false);
            anim.SetBool("isPatrolling", false);
            //Chase();
        }
    }

    public void Chase()
    {
        speed = 3;

        //if the player is in range for melee attack it stops moving and starts damaging the player
        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
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
            //Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            anim.SetBool("isFollowing", true);
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }

    }
}