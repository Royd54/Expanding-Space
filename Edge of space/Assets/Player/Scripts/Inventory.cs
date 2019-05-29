using System.Collections;
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

    private bool crafted = false;
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

    [SerializeField] private GameObject spaceShip;
    [SerializeField] private GameObject InteractKey;

    [SerializeField] private Text RecipeText;
    [SerializeField] private GameObject infoRecipe1;
    [SerializeField] private GameObject infoRecipe2;

    [SerializeField] private Text woodText;
    [SerializeField] private Text stoneText;
    [SerializeField] private Text metalText;

    [SerializeField] private bool inInventory = false;

    private void Start()
    {
        ChangeTool();
    }

    void Update()
    {
        woodText.text = "Wood: " + woodAmount;
        stoneText.text = "Stone: " + stoneAmount;
        metalText.text = "Metal: " + metalAmount;

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
                inventoryUI.SetActive(false);
                playerUI.SetActive(true);
                inInventory = false;
                InteractKey.SetActive(false);
                metalNeeded = 0;
                stoneNeeded = 0;
                woodNeeded = 0;
                infoRecipe1.SetActive(false);
                infoRecipe2.SetActive(false);
                RecipeText.text = "";
                craftedRecipe1 = false;
                craftedRecipe2 = false;
                GameObject.Find("gun").GetComponent<Gun>().ableToFire = true;
            }
        }

        if (Vector2.Distance(transform.position, spaceShip.transform.position) > 10)
        {
            inventoryUI.SetActive(false);
            playerUI.SetActive(true);
            inInventory = false;
            InteractKey.SetActive(false);
            metalNeeded = 0;
            stoneNeeded = 0;
            woodNeeded = 0;
            infoRecipe1.SetActive(false);
            infoRecipe2.SetActive(false);
            RecipeText.text = "";
            craftedRecipe1 = false;
            craftedRecipe2 = false;
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
        metalNeeded = 70;
        stoneNeeded = 20;
        woodNeeded = 0;
        RecipeText.text = "Items Needed: " + metalNeeded + " metal/" + stoneNeeded + "stone";
        infoRecipe1.SetActive(true);
        infoRecipe2.SetActive(false);
        craftedRecipe1 = true;
        craftedRecipe2 = false;
    }

    public void Recipe2()
    {
        metalNeeded = 0;
        stoneNeeded = 0;
        woodNeeded = 0;
        RecipeText.text = "";
        infoRecipe1.SetActive(false);
        infoRecipe2.SetActive(true);
        craftedRecipe1 = false;
        craftedRecipe2 = false;
        craftedRecipe3 = false;
        craftedRecipe4 = true;
        craftedRecipe5 = false;
        craftedRecipe6 = false;
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
            GameObject.Find("gun").GetComponent<Gun>().setDamage();
        }
        if (craftedRecipe6 == true)
        {
            GameObject.Find("gun").GetComponent<Gun>().setDamage();
        }


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
