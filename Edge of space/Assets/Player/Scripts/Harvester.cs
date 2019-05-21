using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Harvester : MonoBehaviour
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
    private GameObject harvester;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        harvester = GameObject.FindWithTag("tool");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
