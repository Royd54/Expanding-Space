using UnityEngine;
using System.Collections;

public class KnockBackPoint : MonoBehaviour
{
    private GameObject player;
    
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    
    void Update()
    {
        /*
        Vector3 targetDir = player.transform.position - transform.position;
        float angle = Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, 500 * Time.deltaTime);
        */
    }
}
