///////////////////////
// Script Contributors:
// Zeb
//
//
///////////////////////

using UnityEngine;

public class RotateAround : MonoBehaviour
{
    [SerializeField] private GameObject orbitalTarget;
    [SerializeField] private Vector3 axis = new(0, 0, 0);
    [SerializeField] private float speed = 6f;

    // Update is called once per frame
    void Update()
    {
        // Calculate the rotation amount per frame, taking time into account
        float rotationAmount = speed * Time.deltaTime;

        // Perform the rotation around the orbital target at a consistent speed
        transform.RotateAround(orbitalTarget.transform.position, axis, rotationAmount);
    }
}
