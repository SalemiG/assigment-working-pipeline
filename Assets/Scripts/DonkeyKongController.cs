using UnityEngine;

/// <summary>
/// Controls Donkey Kong and barrel spawning
/// </summary>
public class DonkeyKongController : MonoBehaviour
{
    [Header("Barrels")]
    [SerializeField] private GameObject barrelPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float spawnInterval = 3f;

    private float spawnTimer;

    private void Start()
    {
        spawnTimer = spawnInterval;
    }

    private void Update()
    {
        spawnTimer -= Time.deltaTime;

        // TODO: When timer reaches 0, spawn a barrel
        // If spawnTimer <= 0:
        //   - Call SpawnBarrel()
        //   - Reset spawnTimer = spawnInterval
    }

    /// <summary>
    /// TODO: Spawns a new barrel
    /// Use Instantiate(barrelPrefab, spawnPoint.position, Quaternion.identity)
    /// </summary>
    private void SpawnBarrel()
    {
        // YOUR CODE HERE
        Debug.Log("Barrel spawned!");
    }
}
