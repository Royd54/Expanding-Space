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
    #region Variables
    [Header("Gun Specs")]
    [SerializeField] private GunEnum firingType = GunEnum.singleShot;
    [SerializeField] private AmmoEnum ammoType = AmmoEnum.arrow;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private int damage;
    [Tooltip("The amount of time between shots(this only apply to autometic weapons)")]
    [SerializeField] public float fireRate;
    [Range(0, 10)]
    [SerializeField] private float spread = 0;
    [SerializeField] private GameObject bullet;

    [Header("Harvester Specs")]
    [SerializeField] private bool canHarvest;
    [Range(1, 30)]
    [Tooltip("the amount of items the player gets every second using the harvester")]
    [SerializeField] private int amountsHarvest = 1;
    [SerializeField] private float range = 10;
    [SerializeField] private LineRenderer lineRenderer;

    private AudioSource audio;
    private GameObject bulletIns;
    private Transform spawner;
    private bool primaryUse = false;
    private bool secondaryUse = false;
    private NuclearThroneLikeCamera cam;
    private float fireRateRestet;
    public bool ableToFire = true;
    #endregion

    private void Start()
    {
        fireRateRestet = fireRate;
        fireRate = 0;
        spawner = transform.Find("Spawner");
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        lineRenderer.enabled = false;
        if (!cam)
        {
            try
            {
                cam = GameObject.FindWithTag("MainCamera").GetComponent<NuclearThroneLikeCamera>();
            }
            catch
            {
                //does nothing
            }
        }
        if (!audio)
        {
            try
            {
                audio = this.GetComponent<AudioSource>();
            }
            catch
            {
                //does nothing
            }
        }

        if (primaryUse && ableToFire == true)
        {
            if (firingType == GunEnum.singleShot)
            {
                //when the gunenum is set to singleshot 
                cam.Shake((this.transform.position - spawner.position).normalized, 3f, 0.05f);
                spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);
                bulletIns.SendMessage("SetDamage", damage);
                bulletIns.SendMessage("SetSpeed", bulletVelocity);
                audio.Play(0);
                primaryUse = false;
            }
            if (firingType == GunEnum.semiAutomatic)
            {
                if(fireRate <= 0)
                {
                    cam.Shake((this.transform.position - spawner.position).normalized, 3f, 0.05f);
                    spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                    bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                    spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);
                    bulletIns.SendMessage("SetDamage", damage);
                    bulletIns.SendMessage("SetSpeed", bulletVelocity);
                    audio.Play(0);
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
            RaycastHit2D hit = Physics2D.Raycast(spawner.position, spawner.right, 10f);

            if (hit.collider != null && hit.collider.tag != "player")
            {
                if (hit.collider.tag == "harvertable")
                {
                    hit.transform.SendMessage("Harvest", amountsHarvest);
                    lineRenderer.enabled = true;
                    lineRenderer.SetPosition(0, GameObject.Find("Spawner").GetComponent<Transform>().position);
                    lineRenderer.SetPosition(1, hit.transform.position);
                }
            }
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

    public void automaticFire()
    {
        this.firingType = GunEnum.semiAutomatic;
        fireRateRestet = 0.2f;
    }

    public void SetShotgun()
    {
        this.firingType = GunEnum.Shotgun;
    }

    public void setDamage()
    {
        damage += 10;
    }

    public void setVelocity()
    {
        bulletVelocity = 80;
    }
}