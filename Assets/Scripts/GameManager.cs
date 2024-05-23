using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text gameOverText;
    public Button restartButton;
    public bool gameOver;
    private CactusSpawner cactusSpawner;
    private void Start()
    {
        cactusSpawner = FindObjectOfType<CactusSpawner>();
    }
    private void Update()
    {
        if(gameOver)
        {
            GameOverUI(true);
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