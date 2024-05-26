using UnityEngine;
using UnityEngine.UI;
public class Points : MonoBehaviour
{
    public Text pointsText;
    public int points = 0;
    private float timer = 0.0f;
    private float interval = 1.0f;
    private GameManager gameManager;
    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        if(gameManager.gameOver)
        {
            points = 0;
            return;
        }
        timer += Time.deltaTime;
        if (timer >= interval)
        {
            points++;
            if (pointsText != null)
            {
                pointsText.text = $"{points}";
            }
            timer = 0.0f;
        }
    }
}