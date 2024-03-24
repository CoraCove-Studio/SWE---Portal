///////////////////////
// Script Contributors:
// Emma Cole
//
//
///////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int playerHealth = 100;
    
    public void TakeDamage(int damage)
    {
        playerHealth -= damage;
        print(playerHealth);
    }
    private void OnTriggerEnter(Collider other)
    {
        //if player enter's a turret's range, starts the firing coroutine
        if (other.CompareTag(TagManager.TURRET))
        {
            other.gameObject.GetComponent<TurretBehavior>().ActivateFiring();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //if player exits a turret's range, stops the firing coroutine
        if (other.CompareTag(TagManager.TURRET))
        {
            other.gameObject.GetComponent<TurretBehavior>().DeactivateFiring();
        }
    }
}
