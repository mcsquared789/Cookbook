using UnityEngine;

public class TriggerHazard : MonoBehaviour
{
    [SerializeField] GameObject hazard;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false; // Turn invisible in play
    }

    private void OnTriggerEnter(Collider other) // When player enters trigger volume
    {
        if (other.gameObject.CompareTag("Player")) // Check player
        {
            hazard.SetActive(true); // Activate specified hazard in scene
        }
    }
}
