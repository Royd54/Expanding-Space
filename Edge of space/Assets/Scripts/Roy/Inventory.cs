﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int woodAmount = 60;
    public int stoneAmount = 20;
    public int metalAmount = 70;
    public GameObject[] selectedWindows;
    private int toolSlotIndex = 0;

    public GameObject Victory;

    private bool craftedRecipe1 = false;
    private bool craftedRecipe2 = false;
    private bool craftedRecipe3 = false;
    private bool craftedRecipe4 = false;
    private bool craftedRecipe5 = false;
    private bool craftedRecipe6 = false;

    [SerializeField] private int woodNeeded;
    [SerializeField] private int stoneNeeded;
    [SerializeField] private int metalNeeded;

    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject inventoryUI;
    [SerializeField] private GameObject repairWindow;

    [SerializeField] private GameObject spaceShip;
    [SerializeField] private GameObject InteractKey;

    [SerializeField] private Text RecipeText;
    [SerializeField] private Text StoneNeededText;
    [SerializeField] private Text WoodNeededText;
    [SerializeField] private Text MetalNeededText;
    [SerializeField] private GameObject infoRecipe1;
    [SerializeField] private GameObject infoRecipe2;
    [SerializeField] private GameObject infoRecipe3;
    [SerializeField] private GameObject infoRecipe4;
    [SerializeField] private GameObject infoRecipe5;
    [SerializeField] private GameObject infoRecipe6;

    [SerializeField] private Text part1Text;
    [SerializeField] private Text part2Text;
    [SerializeField] private Text part3Text;

    private bool part1Collected = false;
    private bool part2Collected = false;
    private bool part3Collected = false;

    [SerializeField] private bool inInventory = false;

    private void Start()
    {
        ChangeTool();
    }

    void Update()
    {

        StoneNeededText.text = stoneNeeded + " X" + " (you have "+ stoneAmount + ")";
        WoodNeededText.text = woodNeeded + " X" + " (you have " + woodAmount + ")"; ;
        MetalNeededText.text = metalNeeded + " X" + " (you have " + metalAmount + ")"; ;

        if (part1Collected == true)
        {
            part1Text.text = "Collected!";
        }

        if (part2Collected == true)
        {
            part2Text.text = "Collected!";
        }

        if (part3Collected == true)
        {
            part3Text.text = "Collected!";
        }

        if (Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if(toolSlotIndex != 3)
            {
                toolSlotIndex++;
                ChangeTool();
            }
        }
        if(Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (toolSlotIndex != 0)
            {
                toolSlotIndex--;
                ChangeTool();
            }
        }

        if (Vector2.Distance(transform.position, spaceShip.transform.position) < 10)
        {
            InteractKey.SetActive(true);
            if (Input.GetKey(KeyCode.E))
            {
                playerUI.SetActive(false);
                inventoryUI.SetActive(true);
                inInventory = true;
                GameObject.Find("gun").GetComponent<Gun>().ableToFire = false;
            }

            if (Input.GetKey(KeyCode.Escape))
            {
                Reset();
                GameObject.Find("gun").GetComponent<Gun>().ableToFire = true;
            }
        }

        if (Vector2.Distance(transform.position, spaceShip.transform.position) > 10)
        {
            Reset();
            GameObject.Find("gun").GetComponent<Gun>().ableToFire = true;
        }
    }

    private void ChangeTool()
    {
        foreach (GameObject toolSlot in selectedWindows)
            toolSlot.SetActive(false);
        selectedWindows[toolSlotIndex].SetActive(true);
    }

    public void Recipe1()
    {
        CraftReset();
        metalNeeded = 70;
        stoneNeeded = 20;
        woodNeeded = 0;
        infoRecipe1.SetActive(true);
        craftedRecipe1 = true;
    }

    public void Recipe2()
    {
        CraftReset();
        metalNeeded = 1;
        stoneNeeded = 1;
        woodNeeded = 1;
        infoRecipe2.SetActive(true);
        craftedRecipe2 = true;
    }
    public void Recipe3()
    {
        CraftReset();
        metalNeeded = 2;
        stoneNeeded = 2;
        woodNeeded = 2;
        infoRecipe3.SetActive(true);
        craftedRecipe3 = true;
    }
    public void Recipe4()
    {
        CraftReset();
        metalNeeded = 3;
        stoneNeeded = 3;
        woodNeeded = 3;
        infoRecipe4.SetActive(true);
        craftedRecipe4 = true;
    }
    public void Recipe5()
    {
        CraftReset();
        metalNeeded = 4;
        stoneNeeded = 4;
        woodNeeded = 4;
        infoRecipe5.SetActive(true);
        craftedRecipe5 = true;
    }
    public void Recipe6()
    {
        CraftReset();
        metalNeeded = 5;
        stoneNeeded = 5;
        woodNeeded = 5;
        infoRecipe6.SetActive(true);
        craftedRecipe6 = true;
    }

    public void RepairWindow()
    {
        inventoryUI.SetActive(false);
        repairWindow.SetActive(true);
    }

    public void craftWindow()
    {
        repairWindow.SetActive(false);
        inventoryUI.SetActive(true);
    }

    public void repairShip()
    {
        if(part1Collected == true && part2Collected == true && part3Collected == true)
        {
            CraftReset();
            Victory.SetActive(true);
            GameObject.Find("Player").GetComponent<PlayerStats>().health += 100000;
        }
    }


    public void Craft()
    {
        if (metalAmount >= metalNeeded && stoneAmount >= stoneNeeded && woodAmount >= woodNeeded)
        {
            metalAmount -= metalNeeded;
            stoneAmount -= stoneNeeded;
            woodAmount -= woodNeeded;
        }
        if (craftedRecipe1 == true)
        {
            GameObject.Find("gun").GetComponent<Gun>().automaticFire();
        }
        if (craftedRecipe2 == true)
        {
            GameObject.Find("Player").GetComponent<PlayerStats>().health += 35;
        }
        if (craftedRecipe3 == true)
        {
            GameObject.Find("gun").GetComponent<Gun>().setDamage();
        }
        if (craftedRecipe4 == true)
        {
            GameObject.Find("gun").GetComponent<Gun>().SetShotgun();
        }
        if (craftedRecipe5 == true)
        {
            GameObject.Find("gun").GetComponent<Gun>().setVelocity();
        }
        if (craftedRecipe6 == true)
        {
            GameObject.Find("gun").GetComponent<Gun>().setDamage();
        }
    }

    private void CraftReset()
    {
        metalNeeded = 0;
        stoneNeeded = 0;
        woodNeeded = 0;
        infoRecipe1.SetActive(false);
        infoRecipe2.SetActive(false);
        infoRecipe3.SetActive(false);
        infoRecipe4.SetActive(false);
        infoRecipe5.SetActive(false);
        infoRecipe6.SetActive(false);
        RecipeText.text = "";
        craftedRecipe1 = false;
        craftedRecipe2 = false;
        craftedRecipe3 = false;
        craftedRecipe4 = false;
        craftedRecipe5 = false;
        craftedRecipe6 = false;
    }

    private void Reset()
    {
        inventoryUI.SetActive(false);
        repairWindow.SetActive(false);
        playerUI.SetActive(true);
        inInventory = false;
        InteractKey.SetActive(false);
        metalNeeded = 0;
        stoneNeeded = 0;
        woodNeeded = 0;
        infoRecipe1.SetActive(false);
        infoRecipe2.SetActive(false);
        infoRecipe3.SetActive(false);
        infoRecipe4.SetActive(false);
        infoRecipe5.SetActive(false);
        infoRecipe6.SetActive(false);
        RecipeText.text = "";
        craftedRecipe1 = false;
        craftedRecipe2 = false;
        craftedRecipe3 = false;
        craftedRecipe4 = false;
        craftedRecipe5 = false;
        craftedRecipe6 = false;
        GameObject.Find("gun").GetComponent<Gun>().ableToFire = true;
    }

    public void AddWood(int wood)
    {
        this.woodAmount += wood;
    }
    public void AddStone(int stone)
    {
        this.stoneAmount += stone;
    }
    public void AddMetal(int metal)
    {
        this.metalAmount += metal;
    }

    public void SetWood(int wood)
    {
        this.woodAmount = wood;
    }
    public void SetStone(int stone)
    {
        this.stoneAmount = stone;
    }
    public void SetMetal(int metal)
    {
        this.metalAmount = metal;
    }

    public int GetWood()
    {
        return woodAmount;
    }
    public int GetStone()
    {
        return stoneAmount;
    }
    public int GetMetal()
    {
        return metalAmount;
    }
}