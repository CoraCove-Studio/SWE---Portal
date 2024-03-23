///////////////////////
// Script Contributors:
// Emma Cole
//
//
///////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretBehavior : MonoBehaviour
{
    [SerializeField] private GameObject playerObject;

    //this is here for testing purposes NOT final location
    private void FixedUpdate()
    {
        LookAtPlayer();
        ShootAtPlayer(); 
    }

    private void LookAtPlayer()
    {
        transform.LookAt(playerObject.transform.position);
    }
    //public so it can be accessed by the player manager
    public void ShootAtPlayer()
    {
        Vector3 rayStart = transform.position;
        Vector3 rayDirection = (playerObject.transform.position - transform.position).normalized;
        float rayLength = 10f;

        // Perform the raycast
        if (Physics.Raycast(rayStart, rayDirection, out RaycastHit hitInfo, rayLength))
        {
            // Check if the collider of the hit object has the tag "player"
            if (hitInfo.collider.CompareTag(TagManager.PLAYER))
            {
                print("hit player");
                //call player TakeDamage()
            }
            else
            {
                Debug.Log("Did not hit player, hit: " + hitInfo.collider.name);
            }
        }
        else
        {
            Debug.Log("Raycast did not hit anything.");
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = (playerObject.transform.position - transform.position).normalized * 10;
        Gizmos.DrawRay(transform.position, direction);
    }

    public void ActivateFiringIndicators()
    {
        //turn light on
    }

    public IEnumerator ActivateFireDelay()
    {
        //ActivateFiringIndicators()
        //Wait for seconds
        //ShootAtPlayer()
        return null;
    }
}
