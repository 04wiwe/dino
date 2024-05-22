using UnityEngine;
public class UI : MonoBehaviour
{
    public GameObject button;
    public GameObject gameOverText;
    private void Update()
    {
        CollisionChecker collisionChecker = FindObjectOfType<CollisionChecker>();
        if(collisionChecker.gameOver)
        {
            button.active = true;
            gameOverText.active = true;
        }
    }
}