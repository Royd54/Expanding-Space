using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPoint : MonoBehaviour
{
    private float attackRange = 100f;

    private float timeBetweenShots;
    [SerializeField] private float startTimeBetweenShots;

    private int minionShootAmount;
    private int minionStartShootAmount;

    private int shootAmount;
    private int startShootAmount;

    [SerializeField] private bool reloading = false;
    [SerializeField] private float reloadTimer = 2f;
    private float startReloadTimer;

    public Animator anim;

    [SerializeField] private bool minionReloading = false;
    [SerializeField] private float minionReloadTimer = 1f;
    private float minionStartReloadTimer;

    private float rotationSpeed = 90f;

    [SerializeField] private GameObject target;
    [SerializeField] private GameObject projectitle;
    [SerializeField] private GameObject minion;

    // Start is called before the first frame update
    void Start()
    {
        //the variables start version are set in this function
        startReloadTimer = reloadTimer;
        startShootAmount = shootAmount;

        minionStartReloadTimer = minionReloadTimer;
        startShootAmount = shootAmount;

        minionStartShootAmount = minionShootAmount;

        timeBetweenShots = startTimeBetweenShots;

        target = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range it rotates towards the player
        float distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToPlayer < attackRange)
        {
            //Here it calculates the angle and it moves towards the target with the rotationspeed
            Vector3 targetDir = target.transform.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, rotationSpeed  * Time.deltaTime);
            anim.SetBool("isFollowing", false);
            anim.SetBool("isAttacking", true);
        }

        //spawns the minions
        MinionSpawn();

        //checks if its not reloading or if the time is right to shoot
        //if it is time to shoot it spawns a projectile and starts the timebetweenshots countdown
        if (timeBetweenShots <= 0 && reloading == false && distanceToPlayer < attackRange)
        {
            Instantiate(projectitle, transform.position, transform.rotation);
            timeBetweenShots = startTimeBetweenShots;
            shootAmount++;
        }
        else
        {
            //timer
            timeBetweenShots -= Time.deltaTime;
        }
        //checks if the maximum shots before reloading
        if (shootAmount >= 35)
        {
            reloading = true;
        }
        //if the maximum amount of shots are met it stops shooting and starts reloading
        if (reloading == true)
        {
            reloadTimer -= Time.deltaTime;
            //after the timer is done it stops reloading 
            if (reloadTimer <= 0)
            {
                reloading = false;
                shootAmount = startShootAmount;
                reloadTimer = startReloadTimer;
            }
        }
    }

    //this function is made the exact same as above
    void MinionSpawn()
    {
        if (timeBetweenShots <= 0 && minionReloading == false)
        {
            Instantiate(minion, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;
            minionShootAmount++;
        }
        else
        {
            timeBetweenShots -= Time.deltaTime;
        }

        if (minionShootAmount >= 1)
        {
            minionReloading = true;
        }

        if (minionReloading == true)
        {
            minionReloadTimer -= Time.deltaTime;
            if (minionReloadTimer <= 0)
            {
                minionReloading = false;
                minionShootAmount = minionStartShootAmount;
                minionReloadTimer = minionStartReloadTimer;
            }
        }
    }
}
