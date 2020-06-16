using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEffect : MonoBehaviour
{
    Vector3 originalPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.GetComponent<MeshRenderer> ().material.color = Color.white;
        originalPosition = new Vector3 (this.gameObject.transform.localScale.x, this.gameObject.transform.localScale.y, this.gameObject.transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown (KeyCode.Mouse0))
        {
            StartCoroutine (ExampleCoroutine ());
        }
    }

    IEnumerator ExampleCoroutine ()
    {
        this.gameObject.transform.localScale = originalPosition * 1.5f;
        this.gameObject.GetComponent<MeshRenderer> ().material.color = Color.red;
        yield return new WaitForSeconds (.2f);
        this.gameObject.transform.localScale = originalPosition;
        this.gameObject.GetComponent<MeshRenderer> ().material.color = Color.white;
    }
}
