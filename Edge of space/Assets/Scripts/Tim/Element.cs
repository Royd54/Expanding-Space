using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Element : MonoBehaviour
{
    public enum ElementEnum
    {
        wood,
        stone,
        metal
    }
    #region Public Variables
    [Header("Stats")]
    public ElementEnum element = ElementEnum.wood;
    [Range(0, 500)]
    public int elementAmount = 100;
    #endregion
    #region Private Variables
    private Inventory playerInventory;
    private Animator anim;
    #endregion

    private void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
        anim = this.GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(1))
        {
            anim.enabled = false;
        }
    }

    private void Harvest(int amountsHarvest)
    {
        anim.enabled = true;
        anim.SetBool("IsBreaking", true);
        elementAmount -= amountsHarvest;
        if (element == ElementEnum.wood && elementAmount > amountsHarvest)
            playerInventory.AddWood(amountsHarvest);
        if (element == ElementEnum.stone && elementAmount > amountsHarvest)
        {
            playerInventory.AddStone(amountsHarvest);
            playerInventory.AddMetal(amountsHarvest);
        }

        if (element == ElementEnum.metal && elementAmount > amountsHarvest)
            playerInventory.AddMetal(amountsHarvest);
    }

    public void TurnOffColliders()
    {
        this.GetComponent<CircleCollider2D>().enabled = false;
        try { this.GetComponent<BoxCollider2D>().enabled = false; }
        catch { }
    }
}
