using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyIndicator : MonoBehaviour
{
    public Transform target;
    public float hideDistance;
    [SerializeField]private GameObject targetIndicator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var dir = target.position - transform.position;

        if(dir.magnitude < hideDistance)
        {
            setChildrenActive(false);
        }
        else
        {
            setChildrenActive(true);

            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }


    void setChildrenActive(bool value)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(value);
        }
    }

}
