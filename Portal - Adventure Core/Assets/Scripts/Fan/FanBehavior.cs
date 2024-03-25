///////////////////////
// Script Contributors:
// Rachel Huggins
//
//
///////////////////////

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// needs to be turned on when button is hit, reference in a "fan motor script?" or on button behaviors?

public class FanBehavior : MonoBehaviour
{
    [SerializeField] private float fanStrength = 10f;
    [SerializeField] private float fanRadius = 5f;

    void OnTriggerStay(Collider other)
    {
        if (other.TryGetComponent<Rigidbody>(out var rb)) // cubes should have rigid body too for physics simulation
        {
            Vector3 direction = transform.position - other.transform.position;
            float distance = direction.magnitude;
            float falloff = 1 - Mathf.Clamp01(distance / fanRadius); // Apply falloff based on distance

            rb.AddForce(falloff * fanStrength * direction.normalized, ForceMode.Force);
        }
    }
}
