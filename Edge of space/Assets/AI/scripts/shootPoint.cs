using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootPoint : MonoBehaviour
{
    private float attackRange = 100f;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    private int minionShootAmount;
    private int minionStartShootAmount;

    private int shootAmount;
    private int startShootAmount;

    public bool reloading = false;
    public float reloadTimer = 2f;
    private float startReloadTimer;

    private Animator anim;

    public bool minionReloading = false;
    public float minionReloadTimer = 4f;
    private float minionStartReloadTimer;

    private float rotationSpeed = 10f;

    public Transform target;

    public GameObject projectitle;
    public GameObject minion;

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

        target = GameObject.Find("Player").GetComponent<Transform>();

        anim = GameObject.Find("witch").GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //If the player is in range it rotates towards the player
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            Vector3 targetDir = target.position - transform.position;
            float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
            Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, q, Random.Range(0f, 90f)  * Time.deltaTime);
            anim.SetBool("isFollowing", false);
            anim.SetBool("isAttacking", true);
        }

        //spawns the minions
        MinionSpawn();

        //checks if its not reloading or if the time is right to shoot
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
        if (shootAmount >= 20)
        {
            reloading = true;
        }
        //if the maximum amount of shots are met it stops shooting and starts reloading
        if (reloading == true)
        {
            reloadTimer -= Time.deltaTime;
            if (reloadTimer <= 0)
            {
                reloading = false;
                shootAmount = startShootAmount;
                reloadTimer = startReloadTimer;
            }
        }
    }

    //this fucntion is made the exact same as above
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
