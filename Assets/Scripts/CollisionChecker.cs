using UnityEngine;
public class CollisionChecker : MonoBehaviour
{
    private Collider2D _collider;
    private GameManager gameManager;
    Collider2D[] results = new Collider2D[32];
    public void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        _collider = GetComponent<Collider2D>();
    }
    private void Update()
    {
        if(gameManager.gameOver)
        {
            return;
        }
        else
        {
            CheckCollisions();
        }
    }
    private void CheckCollisions()
    {
        _collider.OverlapCollider(new ContactFilter2D(), results);
        for(int i = 0; i < results.Length; i++)
        {
            if(results[i] != null)
            {
                results[i] = null;
                gameManager.gameOver = true;
            }
        }
    }
}