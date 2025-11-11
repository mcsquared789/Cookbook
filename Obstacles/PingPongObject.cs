using UnityEngine;

public class PingPongObject : MonoBehaviour
{
    [SerializeField] private Vector3 movementVector;
    [SerializeField] private float moveSpeed = 1f;
    
    private Vector3 _startPosition; 
    private Vector3 _endPosition;
    private float _movementFactor;

    private void Start()
    {
        // Set start position to current location and add movement vector to create end position
        _startPosition = transform.position;
        _endPosition = _startPosition + movementVector;
    }

    private void Update()
    {
        // PingPong to move back and forth between 0 and 1, Lerp to track current position from start to end
        _movementFactor = Mathf.PingPong(Time.time * moveSpeed, 1f);
        transform.position = Vector3.Lerp(_startPosition, _endPosition, _movementFactor);
    }
}
