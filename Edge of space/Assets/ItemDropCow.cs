using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDropCow : MonoBehaviour
{
    public GameObject flesh;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.GetComponent<cowHealthController>().health <= 0)
        {
            Instantiate(flesh, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
