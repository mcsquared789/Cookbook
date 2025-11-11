using UnityEngine;

public class SimplePlayerScore : MonoBehaviour // See ObstacleCollision
{
    public int playerScore;
    
    private void OnCollisionEnter(Collision other)
    {
        // Obstacle does not have tag assigned
        if (!other.gameObject.CompareTag("ObstacleHit")) 
        {
            playerScore += 1;
            Debug.Log("Score is now " + playerScore);
            // Tag accounts for the obstacle having already been hit once
        }
        
    }
}
