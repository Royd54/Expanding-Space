using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaker : MonoBehaviour
{
    public IEnumerator Shake(float time, float force)
    {
        Vector3 beginPos = transform.localPosition;

        float elapsed = 0.0f;

        while (elapsed < time)
        {
            float x = Random.Range(-1, 1f) * force;
            float y = Random.Range(-1, 1f) * force;

            transform.localPosition = new Vector3(x, y, beginPos.z);

            elapsed += Time.deltaTime;

            yield return null;
        }

        transform.localPosition = beginPos;
    }

    private void Update()
    {
        //if (Input.GetMouseButtonDown(0))
            //StartCoroutine(Shake(0.1f, 0.1f));
    }


}