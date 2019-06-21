using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    #region Variables
    [Header("Gun Specs")]
    [SerializeField] private bool fullAuto = false;
    private static bool FULLAUTO = false;
    [SerializeField] private bool shotgun = false;
    private static bool SHOTGUN = false;
    [SerializeField] private bool lazer = false;
    private static bool LAZER = false;
    [SerializeField] private float bulletVelocity;
    [SerializeField] private int damage;
    [Tooltip("The amount of time between shots(this only apply to autometic weapons)")]
    [SerializeField] public float fireRate;
    private static float FIRERATE;
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
    public bool ableToFire = true;
    #endregion

    private void Start()
    {
        fireRate = FIRERATE;
        fullAuto = FULLAUTO;
        shotgun = SHOTGUN;
        lazer = LAZER;

        fireRate = 0;
        spawner = transform.Find("Spawner");
        lineRenderer = this.gameObject.GetComponent<LineRenderer>();
    }

    private void Update()
    {
        if (fireRate > 0)
            fireRate -= Time.deltaTime;

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
            if (fullAuto)
            {
                if (fireRate <= 0)
                {
                    cam.Shake((this.transform.position - spawner.position).normalized, 3f, 0.05f);
                    if (lazer)
                    {
                        if (shotgun)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                                bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                                spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);
                                bulletIns.SendMessage("SetDamage", damage / 3);
                                bulletIns.SendMessage("SetSpeed", bulletVelocity);
                            }
                            audio.Play(0);
                        }
                        else
                        {
                            spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                            bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                            spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);

                            bulletIns.SendMessage("SetDamage", damage);
                            bulletIns.SendMessage("SetSpeed", bulletVelocity);
                            audio.Play(0);
                        }
                    }
                    else
                    {
                        if (shotgun)
                        {
                            for (int i = 0; i < 4; i++)
                            {
                                spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                                bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                                spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);
                                bulletIns.SendMessage("SetDamage", damage / 3);
                                bulletIns.SendMessage("SetSpeed", bulletVelocity);
                            }
                            audio.Play(0);
                        }
                        else
                        {
                            spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                            bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                            spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);

                            bulletIns.SendMessage("SetDamage", damage);
                            bulletIns.SendMessage("SetSpeed", bulletVelocity);
                            audio.Play(0);
                        }
                    }
                    fireRate = FIRERATE;
                }

            }
            else
            {
                cam.Shake((this.transform.position - spawner.position).normalized, 3f, 0.05f);
                if (lazer)
                {
                    if (shotgun)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                            bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                            spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);
                            bulletIns.SendMessage("SetDamage", damage / 3);
                            bulletIns.SendMessage("SetSpeed", bulletVelocity);
                        }
                        audio.Play(0);
                    }
                    else
                    {
                        spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                        bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                        spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);

                        bulletIns.SendMessage("SetDamage", damage);
                        bulletIns.SendMessage("SetSpeed", bulletVelocity);
                        audio.Play(0);
                    }
                }
                else
                {
                    if (shotgun)
                    {
                        for (int i = 0; i < 4; i++)
                        {
                            spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                            bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                            spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);
                            bulletIns.SendMessage("SetDamage", damage / 3);
                            bulletIns.SendMessage("SetSpeed", bulletVelocity);
                        }
                        audio.Play(0);
                    }
                    else
                    {
                        Debug.Log("1");
                        spawner.localRotation = Quaternion.AngleAxis(Random.Range(-spread, spread), spawner.forward);
                        bulletIns = Instantiate(bullet, spawner.position, spawner.rotation);
                        spawner.localRotation = Quaternion.AngleAxis(0, spawner.forward);

                        bulletIns.SendMessage("SetDamage", damage);
                        bulletIns.SendMessage("SetSpeed", bulletVelocity);
                        audio.Play(0);
                    }
                }
                primaryUse = false;
            }
        }
            
           
        if (secondaryUse && canHarvest)
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
        fullAuto = true;
        FULLAUTO = true;
        fireRate = 0.2f;
        FIRERATE = 0.2f;
    }

    public void SetShotgun()
    {
        shotgun = true;
        SHOTGUN = true;
        spread = 15;
    }

    public void setDamage()
    {
        if (shotgun)
            damage += 5;
        else
            damage += 10;
    }

    public void setVelocity()
    {
        bulletVelocity = 80;
    }

    public void SetLazer()
    {
        lazer = true;
        LAZER = true;
    }
}