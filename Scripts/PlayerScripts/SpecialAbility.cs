using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialAbility : MonoBehaviour
{
    [SerializeField] bool consumedEnemy;

    private void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            consumedEnemy = true;
            other.GetComponent<Damage> ().UpdateDamage (1);

            GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("SpecialAbilityDeactivate");
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerSpecialAbility> ().ResetSpecialPoints ();
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerHealth> ().MakeHealthMax ();
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerSpecialAbility> ().TurnOffSpecialAbility ();
            //Destroy (other.gameObject);
        }
        else if (other.gameObject.tag == "SpinningBoss")
        {
            consumedEnemy = true;
            other.GetComponent<Damage> ().UpdateDamage (1);

            GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("SpecialAbilityDeactivate");
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerSpecialAbility> ().ResetSpecialPoints ();
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerHealth> ().MakeHealthMax ();
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerSpecialAbility> ().TurnOffSpecialAbility ();
        }
        else if (other.gameObject.tag == "SpinningEnemy")
        {
            consumedEnemy = true;
            other.GetComponent<Damage> ().UpdateDamage (1);

            GameObject.FindGameObjectWithTag ("AudioManager").GetComponent<BR_AudioManager> ().Play ("SpecialAbilityDeactivate");
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerSpecialAbility> ().ResetSpecialPoints ();
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerHealth> ().MakeHealthMax ();
            GameObject.FindGameObjectWithTag ("Player").GetComponent<BR_PlayerSpecialAbility> ().TurnOffSpecialAbility ();
        }
    }

    public bool ConsumedEnemy ()
    {
        return consumedEnemy;
    }

    public void ResetAbility ()
    {
        consumedEnemy = false;
    }

}
