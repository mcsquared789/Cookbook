using System;
using UnityEngine;

public class DroppingObject : MonoBehaviour
{
    [SerializeField] private float timeElapsed = 3f;
    
    // Cached components
    private MeshRenderer _thisMeshRenderer;
    private Rigidbody _thisRigidbody;

    void Start()
    {
        _thisMeshRenderer = GetComponent<MeshRenderer>();
        _thisRigidbody = GetComponent<Rigidbody>();
        
        _thisMeshRenderer.enabled = false; // Turn invsible
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
