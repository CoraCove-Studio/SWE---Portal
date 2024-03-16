///////////////////////
// Script Contributors:
// Zeb
//
//
///////////////////////

using UnityEngine;

public class PortalCamera : MonoBehaviour
{
    [SerializeField] private Transform playerCamera;
    [SerializeField] private Transform portal;
    [SerializeField] private Transform otherPortal;
    [SerializeField] private Camera self;
    [SerializeField] private Camera playerCamera_cam;


    private void Awake()
    {
        if (playerCamera == null)
        {
            GameObject _player = GameObject.FindWithTag("Player");
            if (_player != null)
            {
                playerCamera_cam = _player.GetComponentInChildren<Camera>();
                playerCamera = playerCamera_cam.transform;
            }
            else
            {
                Debug.Log("Could not find the player, player cam is unset.");
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        // Calculate the player's offset from the other portal in the local coordinate system of the other portal.
        Vector3 playerOffsetFromPortal = otherPortal.InverseTransformPoint(playerCamera.position);

        // Apply the offset to the local coordinate system of the portal.
        transform.position = portal.TransformPoint(playerOffsetFromPortal);

        // Calculate the relative rotation from the other portal to the portal.
        Quaternion relativeRotation = Quaternion.Inverse(otherPortal.rotation) * portal.rotation;

        // Apply this relative rotation to the player's orientation to get the new camera orientation.
        transform.rotation = relativeRotation * playerCamera.rotation;

        // Update the field of view to match the player's camera.
        self.fieldOfView = playerCamera_cam.fieldOfView;
    }
}
