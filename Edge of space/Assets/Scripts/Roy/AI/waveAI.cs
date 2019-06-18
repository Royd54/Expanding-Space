using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveAI : MonoBehaviour
{
    [SerializeField] private float speed;

    [SerializeField] private float minX;
    [SerializeField] private float minY;
    [SerializeField] private float maxX;
    [SerializeField] private float maxY;
    [SerializeField] private float stoppingDistance;

    [SerializeField] private GameObject player;
    private Animator anim;

    [SerializeField] private float damage = 35;
    [SerializeField] private float fireRate = 1F;
    private float nextFire = 0.0F;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.gameObject.GetComponent<Animator>();
        player = GameObject.Find("Player");
        speed = 2;

        Physics2D.IgnoreCollision(this.GetComponent<CircleCollider2D>(), this.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    private void FixedUpdate()
    {

        speed = 3;
        //if the player is in range for melee attack it stops moving and starts damaging the player
        if (Vector3.Distance(transform.position, player.transform.position) < 3f)
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