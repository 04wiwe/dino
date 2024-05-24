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
    private void Start()
    {
        points = FindObjectOfType<Points>();
        cactusSpawner = FindObjectOfType<CactusSpawner>();
    }
    private void Update()
    {
        if(gameOver)
        {
            GameOverUI(true);
        }
        else if(points.points > pointsTemp + 25)
        {
            cactusSpawner.cactusSpeed += 1.0f;
            
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