using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeColor : MonoBehaviour
{
    public MeshRenderer rend;
    public float minTime;
    public float maxTime;

    private void Start()
    {
        rend = GetComponent<MeshRenderer>();
        StartCoroutine(Hologram());
    }

    IEnumerator Hologram()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minTime, maxTime));
            rend.enabled = !rend.enabled;
        }
    }

}
