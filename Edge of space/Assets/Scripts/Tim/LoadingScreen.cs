using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadingScreen : MonoBehaviour
{
    [SerializeField] private GameObject player;
    public Animator anim;

    public void SpawnPlayer()
    {
        Instantiate(player, this.transform.position, this.transform.rotation);
        anim = this.transform.parent.GetComponent<Animator>();
        anim.SetBool("Done", true);
    }
}
