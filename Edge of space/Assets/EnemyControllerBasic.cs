using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControllerBasic : MonoBehaviour
{

    public float speed;
    private float waitTime;
    public float startWaitTime;

    public Transform moveSpot;
    public float minX;
    public float minY;
    public float maxX;
    public float maxY;
    private GameObject player;
    private Animator anim;

    public int damage = 35;
    public float fireRate = 1F;
    private float nextFire = 0.0F;

    private Color matDefault;
    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        anim = GameObject.Find("Enemy").GetComponent<Animator>();
        player = GameObject.Find("Player");
        waitTime = startWaitTime;
        //sets a random moveposition between the x and the y values
        moveSpot.position = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

        speed = 2;
        //sets the basic color to the color it is on (on run)
        sr = GetComponent<SpriteRenderer>();
        matDefault = sr.color;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.P))
        {
            whiteFlash();
        }
        else
        {
            Invoke("ResetMaterial", 1f);
        }

        //checks if the player is in range of the anemy
        if (Vector3.Distance(transform.position, player.transform.position) > 30)
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
        if (Vector3.Distance(transform.position, player.transform.position) <= 2.5)
        {
            anim.SetBool("isFollowing", false);
            anim.SetBool("isAttacking", true);
            anim.SetBool("isPatrolling", false);
            transform.position = this.transform.position;

            if (Time.time > nextFire)
            {
                //does damage if the timer is 0
                nextFire = Time.time + fireRate;
                player.SendMessage("TakeDamage", damage);
            }
        
            // transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
        }
        //he walks towards the player
        else
        {
            Debug.Log(Vector3.Distance(transform.position, player.transform.position));
            anim.SetBool("isFollowing", true);
            speed *= 2;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

        }

    }

    //sets the object its color to white
    void whiteFlash()
    {
            sr.color = Color.white;
    }

    //resets the material to the default color
    void ResetMaterial()
    {
        sr.color = matDefault;
    }

}