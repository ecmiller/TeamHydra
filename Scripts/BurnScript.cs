using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnScript : MonoBehaviour
{
    // Empty script used to located the burn effect for each of the playable characters.
    public string characterName;

    private void Start()
    {
        Debug.Log(gameObject.name + " successfully found");
    }
}
