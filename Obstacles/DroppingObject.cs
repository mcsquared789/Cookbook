using UnityEngine;

public class DroppingObject : MonoBehaviour // See TriggerHazard
{
    [SerializeField] private float timeElapsed = 3f;
    
    // Cached components
    private MeshRenderer _thisMeshRenderer;
    private Rigidbody _thisRigidbody;

    void Awake()
    {
        gameObject.SetActive(false); // Disable dropper at beginning of game
    }
    
    void Start()
    {
        _thisMeshRenderer = GetComponent<MeshRenderer>();
        _thisRigidbody = GetComponent<Rigidbody>();
        
        _thisMeshRenderer.enabled = false; // Turn invisible
    }

    void Update()
    {
        if (Time.time > timeElapsed) // When time runs out, make visible and activate gravity
        {
            _thisMeshRenderer.enabled = true;
            _thisRigidbody.useGravity = true;
        }
    }
}
