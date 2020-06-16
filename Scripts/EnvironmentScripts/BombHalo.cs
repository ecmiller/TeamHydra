using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters;
using UnityEditor;
using UnityEngine;

// Tutorial used: Unity 3d Lerp Scale Simple Scripting Series in C# - https://youtu.be/GB5mKBALeZw
public class BombHalo : MonoBehaviour
{
    public Bomb bombToFollow;
    public Color startColor;
    public Color endColor;

    public float expansionSpeed = 1f;

    IEnumerator Start()
    {
        if (bombToFollow == null)
        {
            Debug.Log("No bomb assigned to explosion halo" + gameObject.name);
        }

        ChangeColor();

        yield return Expand(bombToFollow.explosionRadius, bombToFollow.fuseTimer);
    }

    // Update is called once per frame
    void Update()
    {
        if (bombToFollow != null)
        {
            transform.position = bombToFollow.transform.position;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    public IEnumerator Expand(float blastRadius, float expansionTime)
    {
        float i = 0f;
        float rate = (1.0f / expansionTime) * expansionSpeed;

        while(i < 1f)
        {
            i += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(blastRadius, 1, blastRadius), i);
            yield return null;
        }

        yield return null;
    }

    public void ChangeColor()
    {
        gameObject.GetComponent<MeshRenderer>().material.color = Color.Lerp(startColor, endColor, bombToFollow.fuseTimer);
    }
}
