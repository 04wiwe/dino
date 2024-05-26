using UnityEngine;
public class CactusSpawner : MonoBehaviour
{
    public GameObject bigCactusPrefab;
    public GameObject smallCactusPrefab;
    public GameObject ground;
    public float spawnIntervalMin = 0.5f;
    public float spawnIntervalMax = 3.0f;
    public float cactusSpeed = 6.0f;
    private float nextSpawnTime;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gameManager.gameOver)
        {
            return;
        }
        else if (Time.time >= nextSpawnTime)
        {
            SpawnCactus();
            ScheduleNextSpawn();
        }
    }
    private void SpawnCactus()
    {
        GameObject cactusPrefab = Random.value > 0.5f ? bigCactusPrefab : smallCactusPrefab;
        Vector3 spawnPosition = new Vector3(transform.position.x, ground.transform.localScale.y/2 + ground.transform.position.y);
        GameObject cactus = Instantiate(cactusPrefab, spawnPosition, Quaternion.identity);
        CactusMovement cactusMovement = cactus.AddComponent<CactusMovement>();
        cactusMovement.speed = cactusSpeed;
    }
    private void ScheduleNextSpawn()
    {
        nextSpawnTime = Time.time + Random.Range(spawnIntervalMin, spawnIntervalMax);
    }
    public void DestroyAllCactuses()
    {
        GameObject[] bigCactus = GameObject.FindGameObjectsWithTag("BigCactus");
        foreach (GameObject cactus in bigCactus)
        {
            Destroy(cactus);
        }
        GameObject[] smallCactus = GameObject.FindGameObjectsWithTag("SmallCactus");
        foreach (GameObject cactus in smallCactus)
        {
            Destroy(cactus);
        }
    }
}
public class CactusMovement : MonoBehaviour
{
    private GameManager gameManager;
    public float speed;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gameManager.gameOver)
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