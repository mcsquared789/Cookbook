using UnityEngine;

public class TriggerHazard : MonoBehaviour
{
    [SerializeField] GameObject hazard1;
    [SerializeField] GameObject hazard2;
    [SerializeField] GameObject hazard3;
    [SerializeField] GameObject hazard4;
    [SerializeField] GameObject hazard5;

    private void Start()
    {
        GetComponent<MeshRenderer>().enabled = false; // Turn invisible in play
    }

    private void OnTriggerEnter(Collider other) // When player enters trigger volume
    {
        if (other.gameObject.CompareTag("Player")) // Check player
        {
            hazard1.SetActive(true); // Activate specified hazard in scene
            hazard2.SetActive(true);
            hazard3.SetActive(true);
            hazard4.SetActive(true);
            hazard5.SetActive(true);
        }
    }
}
