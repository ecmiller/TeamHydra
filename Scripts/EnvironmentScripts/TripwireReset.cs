using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TripwireReset : MonoBehaviour
{
    public GameObject trapDoor;
    public GameObject button;

    public void Reset()
    {
        trapDoor.SetActive(true);

        if (button != null)
        {
            button.GetComponent<TripwireButton>().ResetTrap();
        }
    }
}
