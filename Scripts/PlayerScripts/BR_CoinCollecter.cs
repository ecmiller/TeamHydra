using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_CoinCollecter : MonoBehaviour
{
    private void OnTriggerStay (Collider other)
    {
        if (other.CompareTag ("Coin"))
        {
            other.transform.position = Vector3.MoveTowards (other.transform.position, this.transform.position, 10f * Time.deltaTime);
        }
    }
}
