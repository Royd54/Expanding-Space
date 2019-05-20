using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraAnimator : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(theSequence());
        cam1.SetActive(true);
        cam2.SetActive(false);
    }

    IEnumerator theSequence()
    {
        yield return new WaitForSeconds(1);
        cam2.SetActive(true);
        cam1.SetActive(false);
    }
}
