using UnityEngine;
public class CactusSpawner : MonoBehaviour
{
    public GameObject bigCactusPrefab;
    public GameObject smallCactusPrefab;
    public float spawnIntervalMin = 0.5f;
    public float spawnIntervalMax = 3.0f;
    public float cactusSpeed = 6.0f;
    public float spawnHeight = -4.0f;
    private float nextSpawnTime;
    private void Start()
    {
        ScheduleNextSpawn();
    }
    private void Update()
    {
        CollisionChecker collisionChecker = FindObjectOfType<CollisionChecker>();
        if(collisionChecker.gameOver)
        {
            return;
        }
        if (Time.time >= nextSpawnTime)
        {
            SpawnCactus();
            ScheduleNextSpawn();
        }
    }
    private void SpawnCactus()
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
    private void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
}
public class CactusMovement : MonoBehaviour
{
    public float speed;
    private void Update()
    {
        CollisionChecker collisionChecker = FindObjectOfType<CollisionChecker>();
        if(collisionChecker.gameOver)
        {
            return;
        }
        transform.Translate(Vector3.left * speed * Time.deltaTime);
        if (transform.position.x < -10.0f)
        {
            Destroy(gameObject);
        }
    }
}