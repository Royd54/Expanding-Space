using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    public GameObject projectitle;
    public GameObject minion;
    public Transform player;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").transform;
        anim = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        anim.SetBool("isFollowing", true);
        //if the player is in range the enemy chases him
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //if the player is getting closer the enenmy stops moving 
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        //if the player is too close to the enemy the enemy retreats
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }
    }
}
