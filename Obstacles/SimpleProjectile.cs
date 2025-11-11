using UnityEngine;

public class SimpleProjectile : MonoBehaviour // See SimpleTriggerProjectile
{
    [SerializeField] public float projectileSpeed = 10f;
    [SerializeField] public Transform player; // get reference to player

    private Vector3 _playerPosition; // player's position

    void Awake()
    {
        gameObject.SetActive(false); // Disable projectile at beginning of game
        // When activated by trigger volume, player position will be determined in Start
    }

    void Start()
    {
        _playerPosition = player.transform.position; // Define player's position
    }

    void Update()
    {
        ProjectileMovement();
        DestroyOnArrival();
    }

    private void ProjectileMovement() // Move towards initial player position
    {
        float modifiedSpeed = projectileSpeed * Time.deltaTime;
        transform.position = 
            Vector3.MoveTowards(transform.position, _playerPosition, modifiedSpeed);
    }

    private void DestroyOnArrival() // When projectile reaches destination, destroy
    {
        if (transform.position == _playerPosition)
        {
            Destroy(gameObject);
        }
    }
}
