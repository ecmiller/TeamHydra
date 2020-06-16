using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_CameraShake : MonoBehaviour
{
    //public IEnumerator Shake (float duration, float magnitude)
    //{
    //    // save the original position of the camera
    //    Vector3 originalPosition = this.gameObject.transform.localPosition;
    //    Vector3 rightposition = new Vector3 (originalPosition.x + .1f, originalPosition.y + .1f, originalPosition.z);
    //    Vector3 leftposition = new Vector3 (originalPosition.x - .1f, originalPosition.y - 1f, originalPosition.z);

    //    // how much time since camera started shaking
    //    float elapsed = 0.0f;

    //    // shake camarea while duration is less than the elapsed time
    //    while (elapsed < duration)
    //    {
    //        //float x = Random.Range (-1f, 1f) * magnitude;
    //        //float y = Random.Range (-1f, 1f) * magnitude;

    //        //transform.localPosition = new Vector3 (x, y, originalPosition.z);

    //        //elapsed += Time.deltaTime;
    //        //yield return null;

    //        if (this.transform.localPosition == originalPosition)
    //        {
    //            this.transform.localPosition = Vector3.Lerp (originalPosition, rightposition, magnitude);
    //        }
    //        else if (this.transform.localPosition == rightposition)
    //        {
    //            this.transform.localPosition = Vector3.Lerp (rightposition, leftposition, magnitude);
    //        }
    //        else if (this.transform.localPosition == leftposition)
    //        {
    //            this.transform.localPosition = Vector3.Lerp (leftposition, rightposition, magnitude);
    //        }

    //        elapsed += Time.deltaTime;
    //        Debug.Log ("Co is working");
    //        yield return null;
    //    }

    //    transform.localPosition = originalPosition;
    //}
    
    [SerializeField] float elapsed = 0.0f;
    [SerializeField] float speed = 150;
    [SerializeField] Vector3 originalPosition;
    [SerializeField] Vector3 rightPosition;
    [SerializeField] Vector3 leftPosition;

    private void OnEnable ()
    {
        elapsed = 0.0f;
        originalPosition = this.gameObject.transform.localPosition;
        rightPosition = new Vector3 (originalPosition.x + .1f, originalPosition.y, originalPosition.z);
        leftPosition = new Vector3 (originalPosition.x - .1f, originalPosition.y, originalPosition.z);
    }
    private void Update ()
    {

        if (this.transform.localPosition == originalPosition)
        {
            this.transform.localPosition = Vector3.Lerp (originalPosition, rightPosition, speed * Time.deltaTime);
        }
        else if (this.transform.localPosition == rightPosition)
        {
            this.transform.localPosition = Vector3.Lerp (rightPosition, leftPosition, speed * Time.deltaTime);
        }
        else if (this.transform.localPosition == leftPosition)
        {
            this.transform.localPosition = Vector3.Lerp (leftPosition, rightPosition, speed * Time.deltaTime);
        }

        elapsed += Time.deltaTime;

        if (elapsed >= .2f)
        {
            if (this.transform.localPosition == rightPosition)
            {
                this.transform.localPosition = Vector3.Lerp (rightPosition, originalPosition, speed * Time.deltaTime);
            }
            else if (this.transform.localPosition == leftPosition)
            {
                this.transform.localPosition = Vector3.Lerp (leftPosition, originalPosition, speed * Time.deltaTime);
            }

            this.enabled = false;
        }
    }
}
