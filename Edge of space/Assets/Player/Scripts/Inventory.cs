﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject[] selectedWindows;
    private int toolSlotIndex = 0;

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
    }

    private void ChangeTool()
    {
        foreach (GameObject toolSlot in selectedWindows)
            toolSlot.SetActive(false);
        selectedWindows[toolSlotIndex].SetActive(true);
    }
}