using System;
using UnityEngine;
using UnityEngine.InputSystem; // INPUT

public class SimplePhysicsMovementRocket : MonoBehaviour // See RocketCollisionHandler
{
    [SerializeField] private InputAction thrust;
    [SerializeField] private InputAction rotate;
    // All input action keys are defined in Unity

    [SerializeField] private float thrustStrength = 1000f;
    [SerializeField] private float rotateStrength = 200f;

    [SerializeField] private AudioClip thrustSfx;
    [SerializeField] private ParticleSystem thrustVfx;
    [SerializeField] private ParticleSystem leftThrusterVfx;
    [SerializeField] private ParticleSystem rightThrusterVfx;

    // Caches
    private Rigidbody _thisRigidbody;
    private AudioSource _thisAudioSource;
    
    private void OnEnable() // When game object is enabled, relevant for all input actions
    {
        thrust.Enable();
        rotate.Enable();
    }

    private void Start()
    {
        // Assign components
        _thisRigidbody = GetComponent<Rigidbody>();
        _thisAudioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate() // FixedUpdate is for anything with physics
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            // Vector3.up is shorthand for (0, 1, 0)
            _thisRigidbody.AddRelativeForce(Vector3.up * (thrustStrength * Time.fixedDeltaTime));

            if (!_thisAudioSource.isPlaying) // Play audio clip only once
                _thisAudioSource.PlayOneShot(thrustSfx);
            
            thrustVfx.Play();
        }
        else // Cut audio/particles when input is finished
        {
            _thisAudioSource.Stop();
            thrustVfx.Stop();
        }
    }

    private void ProcessRotation()
    {
        float rotationInput = rotate.ReadValue<float>();

        if (rotationInput != 0)
        {
            _thisRigidbody.freezeRotation = true; // Freeze normal physics while rotating
            
            transform.Rotate(Vector3.forward, -rotationInput * rotateStrength * Time.fixedDeltaTime);
            // force and angle to rotate in (inverted to account for coordinates)
            
            // Particles for rotation
            if (rotationInput > 0)
                leftThrusterVfx.Play();
            if (rotationInput < 0)
                rightThrusterVfx.Play();
        }
        else // Resume physics and disable particles
        {
            _thisRigidbody.freezeRotation = false;
            leftThrusterVfx.Stop();
            rightThrusterVfx.Stop();
        }
        
    }
}
