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
        CheckCollisions();
    }
    private void CheckCollisions()
    {
        _collider.OverlapCollider(new ContactFilter2D(), results);
        foreach(Collider2D i in results)
        {
            if(i != null)
            {
                gameManager.gameOver = true;
            }            
        }
    }
}