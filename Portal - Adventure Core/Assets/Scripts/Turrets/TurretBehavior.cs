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
    [SerializeField] private GameObject spotlight;

    [Header("Outside Scripts")]
    [SerializeField] private PlayerManager playerManager;

    private void FixedUpdate()
    {
        LookAtPlayer();
    }

    private void LookAtPlayer()
    {
        transform.LookAt(playerObject.transform.position);
    }
    //public so it can be accessed by the player manager
    private void ShootAtPlayer()
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
                playerManager.TakeDamage(1);
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

    //draws a gizmo the length of the raycast to help visualize for level design
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 direction = (playerObject.transform.position - transform.position).normalized * 10;
        Gizmos.DrawRay(transform.position, direction);
    }

    public void ActivateFiring()
    {
        //turn light on
        spotlight.SetActive(true);
        //audio cue goes here

        //begin firing
        InvokeRepeating("ShootAtPlayer", 0.5f, 0.5f);
    }

    public void DeactivateFiring()
    {
        //turn light off
        spotlight.SetActive(false);
        //turn audio cue off? if repeating. otherwise ignore.
        //end firing
        CancelInvoke("ShootAtPlayer");
    }
}
