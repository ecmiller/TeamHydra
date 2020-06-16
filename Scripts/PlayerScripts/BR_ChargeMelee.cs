using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BR_ChargeMelee : MonoBehaviour
{
    Animator anim;

    public void Start()
    {
        anim = GetComponent<Animator>(); 
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Enemy") && other.isTrigger == false)
        {
            if (this.gameObject.transform.parent.name == "Coal")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();                  
                }
            }
            else if (this.gameObject.transform.parent.name == "Crate")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                }
            }
            else if (this.gameObject.transform.parent.name == "Salt")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                }
            }
        }
        else if (other.CompareTag("SpinningBoss") && other.isTrigger == false)
        {
            if (this.gameObject.transform.parent.name == "Coal")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                }
            }
            else if (this.gameObject.transform.parent.name == "Crate")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                }
            }
            else if (this.gameObject.transform.parent.name == "Salt")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                }
            }
        }
        else if (other.CompareTag("SpinningEnemy") && other.isTrigger == false)
        {
            if (this.gameObject.transform.parent.name == "Coal")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                }
            }
            else if (this.gameObject.transform.parent.name == "Crate")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                }
            }
            else if (this.gameObject.transform.parent.name == "Salt")
            {
                if (this.gameObject.transform.parent.GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
                {
                    other.gameObject.GetComponent<Damage>().TakeDamage();
                }
            }
        }
        

           //if (GameObject.Find("Coal").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
           //{
           //   other.gameObject.GetComponent<Damage>().TakeDamage();
           //}

            //if (GameObject.Find("Crate").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
            //{
            //    other.gameObject.GetComponent<Damage>().TakeDamage();
            //}

            //if (GameObject.Find("Salt").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
            //{
            //    other.gameObject.GetComponent<Damage>().TakeDamage();
            //}
    }
        //else if (other.CompareTag("SpinningBoss") && other.isTrigger == false)
        //{

            //if (GameObject.Find("Coal").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
            //{
            //    other.gameObject.GetComponent<Damage>().TakeDamage();
            //}

            //if (GameObject.Find("Crate").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
            //{
            //    other.gameObject.GetComponent<Damage>().TakeDamage();
            //}

            //if (GameObject.Find("Salt").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
            //{
            //    other.gameObject.GetComponent<Damage>().TakeDamage();
            //}
        //}
        //else if (other.CompareTag("SpinningEnemy") && other.isTrigger == false)
        //{

          //  if (GameObject.Find("Coal").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
          //  {
          //      other.gameObject.GetComponent<Damage>().TakeDamage();
          //  }

          //if (GameObject.Find("Crate").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
          //  {
          //      other.gameObject.GetComponent<Damage>().TakeDamage();
          //  }
          
          //if (GameObject.Find("Salt").GetComponent<BR_MeleeAttacks>().chargeCanHurt == true)
          //  {
          //      other.gameObject.GetComponent<Damage>().TakeDamage();
          //   }
        

}



