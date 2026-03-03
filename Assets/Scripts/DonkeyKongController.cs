using UnityEngine;

/// <summary>
/// Controls Donkey Kong at the top of the level - throwing barrels and animations.
/// Spawns BarrelController instances. Controlled by LevelManager.
/// </summary>
public class DonkeyKongController : MonoBehaviour
{
    [Header("Barrel Spawning")]
    [SerializeField] private GameObject barrelPrefab;
    [SerializeField] private Transform barrelSpawnPoint;
    [SerializeField] private float barrelSpawnInterval = 3f;
    [SerializeField] private float barrelSpawnIntervalVariation = 1f;
    [SerializeField] private float initialBarrelSpeed = 3f;
    [SerializeField] private float barrelSpeedIncrement = 0.2f;

    [Header("Behavior Settings")]
    [SerializeField] private bool isThrowingBarrels = false;
    [SerializeField] private int maxBarrelsAtOnce = 8;
    [SerializeField] private bool randomizeDirection = true;

    [Header("Animation")]
    [SerializeField] private Animator animator;
    [SerializeField] private string throwAnimationTrigger = "Throw";

    private float throwTimer;
    private float currentBarrelSpeed;
    private int barrelsThrown = 0;
    private int activeBarrelCount = 0;

    private void Start()
    {
        currentBarrelSpeed = initialBarrelSpeed;

        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }

        // Calculate first throw time with variation
        throwTimer = GetNextThrowInterval();
    }

    private void Update()
    {
        if (!isThrowingBarrels) return;

        throwTimer -= Time.deltaTime;

        if (throwTimer <= 0f && activeBarrelCount < maxBarrelsAtOnce)
        {
            ThrowBarrel();
            throwTimer = GetNextThrowInterval();
        }
    }

    /// <summary>
    /// Starts DK's barrel throwing behavior. Called by LevelManager.
    /// </summary>
    public void StartThrowingBarrels()
    {
        isThrowingBarrels = true;
        Debug.Log("DonkeyKong started throwing barrels!");
    }

    /// <summary>
    /// Stops DK's barrel throwing. Called by LevelManager on game over or level complete.
    /// </summary>
    public void StopThrowingBarrels()
    {
        isThrowingBarrels = false;
        Debug.Log("DonkeyKong stopped throwing barrels!");
    }

    private void ThrowBarrel()
    {
        if (barrelPrefab == null || barrelSpawnPoint == null)
        {
            Debug.LogWarning("BarrelPrefab or SpawnPoint not set!");
            return;
        }

        // TODO: Play throw animation
        // Trigger animator if available

        // Spawn barrel
        GameObject barrel = Instantiate(barrelPrefab, barrelSpawnPoint.position, Quaternion.identity);
        BarrelController barrelController = barrel.GetComponent<BarrelController>();

        if (barrelController != null)
        {
            // Set barrel properties
            bool throwRight = randomizeDirection ? Random.value > 0.5f : true;
            barrelController.SetDirection(throwRight);
            barrelController.SetSpeed(currentBarrelSpeed);
        }

        barrelsThrown++;
        activeBarrelCount++;

        // TODO: Increase difficulty over time
        // Every N barrels, increase currentBarrelSpeed by barrelSpeedIncrement
        // Every N barrels, decrease barrelSpawnInterval (make DK throw faster)
        // Respect minimum spawn interval to keep game fair

        Debug.Log($"Barrel thrown! Total: {barrelsThrown}, Active: {activeBarrelCount}");
    }

    private float GetNextThrowInterval()
    {
        // Add randomness to throw timing
        float variation = Random.Range(-barrelSpawnIntervalVariation, barrelSpawnIntervalVariation);
        return Mathf.Max(0.5f, barrelSpawnInterval + variation);
    }

    /// <summary>
    /// Called when a barrel is destroyed to track active count.
    /// </summary>
    public void OnBarrelDestroyed()
    {
        activeBarrelCount--;
        activeBarrelCount = Mathf.Max(0, activeBarrelCount);
    }

    /// <summary>
    /// Resets DK to initial state. Called by LevelManager on restart.
    /// </summary>
    public void ResetState()
    {
        // TODO: Implement reset logic
        // 1. Stop throwing barrels
        // 2. Reset counters (barrelsThrown, activeBarrelCount)
        // 3. Reset currentBarrelSpeed to initialBarrelSpeed
        // 4. Reset throwTimer
        Debug.Log("DonkeyKong state reset");
    }

    /// <summary>
    /// Changes throw interval for dynamic difficulty. Called by LevelManager.
    /// </summary>
    public void SetThrowInterval(float newInterval)
    {
        barrelSpawnInterval = Mathf.Max(0.5f, newInterval);
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize barrel spawn point
        if (barrelSpawnPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(barrelSpawnPoint.position, 0.5f);
            Gizmos.DrawLine(barrelSpawnPoint.position, barrelSpawnPoint.position + Vector3.right * 2f);
        }
    }
}
