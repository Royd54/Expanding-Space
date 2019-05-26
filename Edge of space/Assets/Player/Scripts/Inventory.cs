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


    [SerializeField] private GameObject playerUI;
    [SerializeField] private GameObject inventoryUI;

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
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
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

        if (Input.GetKey(KeyCode.Tab))
        {
            woodText.text = "Wood: " + woodAmount;
            stoneText.text = "Stone: " + stoneAmount;
            metalText.text = "Metal: " + metalAmount;
            playerUI.SetActive(false);
            inventoryUI.SetActive(true);
            inInventory = true;

        }

        if (Input.GetKey(KeyCode.Escape))
        {
            inventoryUI.SetActive(false);
            playerUI.SetActive(true);
            inInventory = false;
        }

    }

    private void ChangeTool()
    {
        foreach (GameObject toolSlot in selectedWindows)
            toolSlot.SetActive(false);
        selectedWindows[toolSlotIndex].SetActive(true);
    }

    public void AddWood(int wood)
    {
        this.woodAmount = wood;
    }
    public void AddStone(int stone)
    {
        this.stoneAmount = stone;
    }
    public void AddMetal(int metal)
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
