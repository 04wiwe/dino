using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public Text gameOverText;
    public Button restartButton;
    public bool gameOver;

    private void Update()
    {
        if(gameOver)
        {
            GameOverUI();
        }
    }
    public void GameOverUI()
    {
        gameOverText.gameObject.SetActive(true);        
    }
}