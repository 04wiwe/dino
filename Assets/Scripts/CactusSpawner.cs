using UnityEngine;
public class CactusSpawner : MonoBehaviour
{
    public GameObject bigCactusPrefab;
    public GameObject smallCactusPrefab;
    public float spawnIntervalMin = 0.5f;
    public float spawnIntervalMax = 3.0f;
    public float cactusSpeed = 6.0f;
    public float spawnHeight = -4f;
    private float nextSpawnTime;
    void Start()
    {
        ScheduleNextSpawn();
    }
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnCactus();
            ScheduleNextSpawn();
        }
    }
    void SpawnCactus()
    {
        GameObject cactusPrefab;
        if(Random.value > 0.5f)
        {
            cactusPrefab = bigCactusPrefab;
        }
        else
        {
            cactusPrefab = smallCactusPrefab;
        }
        Vector3 spawnPosition = new Vector3(transform.position.x, spawnHeight, transform.position.z);
        GameObject cactus = Instantiate(cactusPrefab, spawnPosition, Quaternion.identity);
        CactusMovement cactusMovement = cactus.AddComponent<CactusMovement>();
        cactusMovement.speed = cactusSpeed;
    }
    void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}
public class CactusMovement : MonoBehaviour
{
    public float speed;
    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}