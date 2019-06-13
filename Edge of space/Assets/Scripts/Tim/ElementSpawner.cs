using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElementSpawner : MonoBehaviour
{
    [SerializeField] private GameObject tree, rock;
    [SerializeField][Range(0, 100)][Tooltip("At what procent spawns a tree")] private float max = 50;
    
    void Start()
    {
        if (Random.Range(0, 100) > max)
            Instantiate(tree, this.transform.position, this.transform.rotation);
        else
            Instantiate(rock, this.transform.position, this.transform.rotation);
    }
}
