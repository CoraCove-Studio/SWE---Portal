using UnityEngine;

public class PortalTeleporter : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Transform receiverTransform;
    PlayerMotor playerMotor;

    private void Awake()
    {
        playerMotor = player.GetComponent<PlayerMotor>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            TeleportPlayer();
        }
    }

    private void TeleportPlayer()
    {
        playerMotor.TeleportPlayer(receiverTransform.position);
    }
}