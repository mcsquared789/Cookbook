using UnityEngine;
using UnityEngine.InputSystem; // INPUT
using UnityEngine.SceneManagement; // SCENE MANAGEMENT

public class RocketCollisionHandler : MonoBehaviour
{
    [SerializeField] float levelDelay = 2f;

    [SerializeField] private AudioClip finishSfx;
    [SerializeField] private AudioClip crashSfx;
    [SerializeField] private ParticleSystem finishVfx;
    [SerializeField] private ParticleSystem crashVfx;
    
    private AudioSource _thisAudioSource;

    private bool _isControllable = true;
    private bool _canCollide = true;

    private void Start()
    {
        _thisAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!_isControllable || !_canCollide) // Ignore all statements once player input is disabled
            return;
        
        switch (other.gameObject.tag)
        {
            case "Safe": // Objects safe to touch like the starting launchpad
                Debug.Log("Safe");
                break;
            
            case "Finish": // End goal of the level
                Debug.Log("Finished");
                CompleteSequence();
                Invoke(nameof(LoadNextLevel), levelDelay);
                break;
            
            default: // When the player collides with anything else, it explodes and level reloads
                Debug.Log("BOOM");
                CrashSequence();
                Invoke(nameof(ReloadLevel), levelDelay); // Coroutine is used in later scripts
                break;
        }
    }
    
    void LoadNextLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int nextScene = currentScene + 1;

        // Restart when we reach the max no. of scenes
        if (nextScene == SceneManager.sceneCountInBuildSettings)
            SceneManager.LoadScene(0);
        else
            SceneManager.LoadScene(nextScene);
    }
    
    private void ReloadLevel()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }

    void CompleteSequence()
    {
        DisableMovement();
        _thisAudioSource.PlayOneShot(finishSfx);
        finishVfx.Play();
    }

    void CrashSequence()
    {
        DisableMovement();
        _thisAudioSource.PlayOneShot(crashSfx);
        crashVfx.Play();
    }

    void DisableMovement()
    {
        // See SimplePhysicsMovementRocket
        GetComponent<SimplePhysicsMovementRocket>().enabled = false;
        _isControllable = false; // Now nothing else can happen during any sequence
        _thisAudioSource.Stop(); // Disable other audio
    }
    
    // DEBUG KEYS
    private void Update()
    {
        DebugKeys();
    }

    void DebugKeys()
    {
        // When L is pressed, load next scene
        if (Keyboard.current.lKey.wasPressedThisFrame)
        {
            LoadNextLevel();
        }
        else if (Keyboard.current.cKey.wasPressedThisFrame)
        {
            _canCollide = !_canCollide; // If false, this resets
            Debug.Log("C Active");
        }
    }
}
