using UnityEngine;

public class SimplePlayerMovementOld : MonoBehaviour
{
    [SerializeField] float playerSpeed = 10f;
    
    void Update()
    {
        MovePlayer();
    }

    void MovePlayer()
    {
        // Player input with GetAxis (Horizontal and vertical, listed in InputManager in settings)
        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * playerSpeed;
        float moveZ = Input.GetAxis("Vertical") * Time.deltaTime * playerSpeed;
        transform.Translate(moveX, 0f, moveZ); // Apply force
    }
}