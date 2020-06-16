using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    Animator anim;
    public AS_Switch script;
    public bool playSound;
    // Start is called before the first frame update
    void Start()
    {
        playSound = false;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(script.Unlocked == true)
        {
            StartCoroutine(openGate());
            script.Unlocked = false;
        }
    }

    IEnumerator openGate()
    {
        yield return new WaitForSeconds(.5f);
        GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("GateOpen");
        anim.SetBool("isUnlocked", true);

    }
}
