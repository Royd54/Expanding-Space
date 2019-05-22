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
    [Range(0,500)]
    public int elementAmount = 100;
    #endregion
    #region Private Variables
    private Inventory playerInventory;
    #endregion

    private void Start()
    {
        playerInventory = GameObject.FindWithTag("Player").GetComponent<Inventory>();
    }

    private void Harvest(int amountsHarvest)
    {
        elementAmount -= amountsHarvest;
        if (element == ElementEnum.wood)
            playerInventory.AddWood(amountsHarvest);
        if (element == ElementEnum.stone)
            playerInventory.AddStone(amountsHarvest);
        if (element == ElementEnum.metal)
            playerInventory.AddMetal(amountsHarvest);

    }
}
