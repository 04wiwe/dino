using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text gameOverText;
    public Button restartButton;
    public bool gameOver;
    private CactusSpawner cactusSpawner;
    private Points points;
    private int pointsTemp = 0;
    private float cactusDefaultSpeed = 0.0f;
    private void Start()
    {
        points = FindObjectOfType<Points>();
        cactusSpawner = FindObjectOfType<CactusSpawner>();
        cactusDefaultSpeed = cactusSpawner.cactusSpeed;
    }
    private void Update()
    {
        if(gameOver)
        {
            cactusSpawner.cactusSpeed = cactusDefaultSpeed;
            GameOverUI(true);
        }
        else if(points.points > pointsTemp + 25)
        {
            cactusSpawner.cactusSpeed += 1.0f;
            cactusSpawner.spawnIntervalMin -= 0.1f;
            cactusSpawner.spawnIntervalMax -= 0.1f;
            pointsTemp = points.points;
        }
    }
    public void RestartGame()
    {
        cactusSpawner.DestroyAllCactuses();
        gameOver = false;
        GameOverUI(false);
    }
    public void GameOverUI(bool gameOverState)
    {
        gameOverText.gameObject.SetActive(gameOverState);
        restartButton.gameObject.SetActive(gameOverState);
    }
}