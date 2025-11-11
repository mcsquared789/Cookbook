using UnityEngine;

public class ObstacleCollision : MonoBehaviour // See PlayerScore
{
    private void OnCollisionEnter(Collision other)
    {
        // Other tag is Player
        if (other.gameObject.CompareTag("Player")) 
        {
            Debug.Log("Player hit");
            GetComponent<MeshRenderer>().material.color = Color.black;
            gameObject.tag = "ObstacleHit";
            // Change obstacle's colour and assign a tag defined in Unity
        }
        
    }
}
