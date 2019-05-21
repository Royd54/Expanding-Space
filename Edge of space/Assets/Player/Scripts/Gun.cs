using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public enum GunEnum
    {
        singleShot,
        semiAutomatic,
        Shotgun,
    }
    public enum AmmoEnum
    {
        arrow,
        pistolBullets,
        rifelAmmo,
        shotgunShell,
        granade,
        lazerCartridge
    }
    #region Public Variables
    [Header("Gun Specs")]
    public GunEnum firingType = GunEnum.singleShot;
    public AmmoEnum ammoType = AmmoEnum.arrow;
    public float bulletVelocity;
    public int damage;
    [Tooltip("The amount of time between shots(this only apply to autometic weapons)")]
    public float fireRate;
    [Range(0,10)]
    public float spread = 0;
    public GameObject bullet;

    [Header("Harvester Specs")]
    public bool canHarvest = false;
    [Range(1,30)][Tooltip("the amount of items the player gets when using the harvester")]
    public int amountsHarvest = 1;
    #endregion
    #region Private Variables
    private GameObject bulletIns;
    private Transform spawner;
    private bool primaryUse = false;
    private bool secondaryUse = false;
    private NuclearThroneLikeCamera cam;
    private float fireRateRestet;
    #endregion

    private void Start()
    {
        fireRateRestet = fireRate;
        fireRate = 0;
        spawner = transform.Find("Spawner");
        cam = GameObject.FindWithTag("MainCamera").GetComponent<NuclearThroneLikeCamera>();
    }

    private void Update()
    {
        if (primaryUse)
        {
            if (firingType == GunEnum.singleShot)
            {
                cam.Shake((this.transform.position - spawner.position).normalized, 3f, 0.05f);
                spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);
                bulletIns.SendMessage("SetDamage", damage);
                bulletIns.SendMessage("SetSpeed", bulletVelocity);
                primaryUse = false;
            }
            if (firingType == GunEnum.semiAutomatic)
            {
                if(fireRate <= 0)
                {
                    cam.Shake((this.transform.position - spawner.position).normalized, 3f, 0.05f);
                    bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                    bulletIns.SendMessage("SetDamage", damage);
                    bulletIns.SendMessage("SetSpeed", bulletVelocity);
                    fireRate = fireRateRestet;
                }
                else
                {
                    fireRate -= Time.deltaTime;
                }
            }
            if (firingType == GunEnum.Shotgun)
            {
                cam.Shake((this.transform.position - spawner.position).normalized, 3f, 0.05f);
                bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                bulletIns.SendMessage("SetDamage", damage);
                bulletIns.SendMessage("SetSpeed", bulletVelocity);
                primaryUse = false;
            }
        }

        if(secondaryUse && canHarvest)
        {
            Debug.Log("harvest");
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                if (hit.transform.tag == "tree")
                    Debug.Log("hit");
        }
    }

    private void SetPrimaryUse(bool primaryUse)
    {
        this.primaryUse = primaryUse;
    }
    private void SetSecondaryUse(bool secondaryUse)
    {
        this.secondaryUse = secondaryUse;
    }
}